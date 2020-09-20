using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

public enum AIState { none, wander, chase}
public class StateManager : MonoBehaviour
{
    public Transform item;

    [Header("Navigation Properties")]
    public float viewRadius = 10;
    [Header("Object Ref")]
    public TextMesh sceneText;
    [Header("Behaviour Settings")]
    public AIState initalState = AIState.wander;
    public Wander wanderState;
    public Chase chaseState;
    public RandomLoot randomLoot;
    public Animator movement;

    private BehaviourState currentState;
    private Vector3 curPos;
    private Vector3 lastPos;

    public NavMeshAgent Agent{ get; private set; }
    public Transform Target { get; private set; }

    private void Awake()
    {
        randomLoot = GetComponent<RandomLoot>();
        movement = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if(initalState == AIState.wander)
        {
            SetState(new Wander(this) { ignoreState = wanderState.ignoreState, boundBox = wanderState.boundBox });
        }
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    void Update()
    {
        if(Target == null)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, viewRadius);
            foreach(Collider collider in collisions)
            {
                if(collider.CompareTag("Player") == true)
                {
                    Target = collider.transform;
                    SetState(new Chase(this, currentState));
                }
            }
        }

        if(currentState != null)
        {
            currentState.Update();
        }

        curPos = this.gameObject.transform.position;

        if (curPos == lastPos)
        {
            movement.SetBool("Walk", false);
        }
        else
        {
            movement.SetBool("Walk", true);
        }
        lastPos = this.gameObject.transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        if(currentState != null)
        {
            currentState.DrawGizmos();
        }
        else if(initalState == AIState.wander)
        {
            wanderState.DrawGizmos();
        }
    }

    public void Attack()
    {
        movement.SetTrigger("Attack");
    }

    public void SetState(BehaviourState newState)
    {
        if(newState.ignoreState == false)
        {
            if(currentState != null)
            {
                currentState.Exit();
            }
            currentState = newState;
            if(sceneText != null)
            {
                sceneText.text = (currentState.GetType().ToString());
            }
            currentState.Initialize();
        }
    }

    public void ClearTarget()
    {
        Target = null;
    }

    public void Death()
    {
        randomLoot.GetRandomItem();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Death();
        }
    }
}
[System.Serializable]
public abstract class BehaviourState
{
    public bool ignoreState = false;

    protected StateManager stateManager;
    protected BehaviourState prevState;

    public BehaviourState(StateManager sm)
    {
        stateManager = sm;
    }

    public virtual void Initialize() { }
    public abstract void Update();
    public virtual void Exit() { }
    public virtual void DrawGizmos() { }
}
[System.Serializable]
public class Wander : BehaviourState
{
    public Bounds boundBox;

    private Vector3? targetPos;
    private float distance;

    public Wander(StateManager sm) : base(sm)
    {

    }

    public override void Initialize()
    {
        stateManager.Agent.isStopped = false;
        FindNewWanderPoint();
    }

    public override void Update()
    {
        if(targetPos != null)
        {
            //if AI has a target switch state
            distance = Vector3.Distance(stateManager.transform.position, (Vector3)targetPos);
            if (distance <= stateManager.Agent.stoppingDistance)
            {
                FindNewWanderPoint();
            }
        }
    }

    public override void Exit()
    {
        
    }

    public override void DrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(boundBox.center, boundBox.size);
        Gizmos.color = Color.red;
        if(targetPos != null)
        {
            Gizmos.DrawSphere((Vector3)targetPos, 0.5f);
        }
    }

    Vector3 GetRandomPointInBounds()
    {
        float randomx = Random.Range(-boundBox.extents.x, boundBox.extents.x) + boundBox.center.x;
        float randomz = Random.Range(-boundBox.extents.z, boundBox.extents.z) + boundBox.center.z;
        Vector3 randomVector = new Vector3(randomx,stateManager.transform.position.y + boundBox.center.y, randomz);
        //if(boundBox.Contains(randomVector) == false)
        //{
        //    randomVector = GetRandomPointInBounds();
        //}
        return randomVector;
    }

    void FindNewWanderPoint()
    {
        targetPos = GetRandomPointInBounds();
        stateManager.Agent.SetDestination((Vector3)targetPos);
    }
}
[System.Serializable]
public class Chase : BehaviourState
{
    public float chaseSpeed = 5;

    private float distance;

    public Chase(StateManager sm) : base(sm)
    {

    }
    public Chase(StateManager sm, BehaviourState prev) : base(sm)
    {
        prevState = prev;
    }

    public override void Initialize()
    {
        stateManager.Agent.isStopped = false;
        stateManager.Agent.speed = chaseSpeed;
    }

    public override void Update()
    {
        if(stateManager.Target != null)
        {
            distance = Vector3.Distance(stateManager.transform.position, stateManager.Target.position);
            if(distance <= stateManager.Agent.stoppingDistance)
            {

            }
            else
            {
                if (distance > stateManager.viewRadius)
                {
                    stateManager.ClearTarget();
                    stateManager.SetState(prevState);
                }
                else
                {
                    stateManager.Agent.SetDestination(stateManager.Target.position);
                }
            }
        }
        else
        {
            if(prevState != null)
            {
                stateManager.SetState(prevState);
            }
        }
    }
}