using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public enum AIState { none, wander, chase, ranged }
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
    public Ranged rangedState; 
    public RandomLoot randomLoot;
    public Animator movement;
    public GameObject explosion;
    public Transform explosionPos;
    public GameObject attackParticles;
    public Transform attackParticlesPos;
    public Rigidbody enemyProjectile;

    private BehaviourState currentState;
    private Vector3 curPos;
    private Vector3 lastPos;

    AudioSource audioSource;

    public AudioClip attackSound;

    public GameObject deathSound;

    public NavMeshAgent Agent { get; private set; }
    public Transform Target { get; private set; }

    /// <summary>
    /// this gets references to some scritps
    /// </summary>
    private void Awake()
    {
        randomLoot = GetComponent<RandomLoot>();
        movement = GetComponentInChildren<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// if the enemy doesnt have a target but the player is inside of its chase range then it will set that player as its target
    /// 
    /// </summary>
    void Update()
    {
        if (Target == null)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, viewRadius);
            foreach (Collider collider in collisions)
            {
                if (collider.CompareTag("Player") == true)
                {
                    Target = collider.transform;
                    SetState(new Chase(this, currentState));
                }
            }
        }

        if (currentState != null)
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

        if (currentState != null)
        {
            currentState.DrawGizmos();
        }
        else if (initalState == AIState.wander)
        {
            wanderState.DrawGizmos();
        }
    }

    public void Attack()
    {
        movement.SetTrigger("Attack");
        audioSource.PlayOneShot(attackSound, 1F);
        GameObject attackParticle = Instantiate(attackParticles, attackParticlesPos.transform.position, attackParticlesPos.transform.rotation);
        Destroy(attackParticle, 1.5f);
    }

    public void SetState(BehaviourState newState)
    {
        if (newState.ignoreState == false)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = newState;
            if (sceneText != null)
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
        GameObject sound = Instantiate(deathSound, transform.position, transform.rotation);
        Destroy(sound, 5f);
        gameObject.SetActive(false);
        Destroy(this.gameObject);
        GameObject Explosion = Instantiate(explosion, explosionPos.transform.position, explosionPos.transform.rotation);
        Destroy(Explosion, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Death();
        }
    }

    public void FireProjectile()
    {
        Rigidbody instantiatedProjectile = Instantiate(enemyProjectile, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, rangedState.projectileSpeed));
        Destroy(instantiatedProjectile.gameObject, rangedState.destroyAfterTime);
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
        if (targetPos != null)
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
        if (targetPos != null)
        {
            Gizmos.DrawSphere((Vector3)targetPos, 0.5f);
        }
    }

    Vector3 GetRandomPointInBounds()
    {
        float randomx = Random.Range(-boundBox.extents.x, boundBox.extents.x) + boundBox.center.x;
        float randomz = Random.Range(-boundBox.extents.z, boundBox.extents.z) + boundBox.center.z;
        Vector3 randomVector = new Vector3(randomx, stateManager.transform.position.y + boundBox.center.y, randomz);
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
        if (stateManager.Target != null)
        {
            distance = Vector3.Distance(stateManager.transform.position, stateManager.Target.position);
            if (distance <= stateManager.Agent.stoppingDistance)
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
            if (prevState != null)
            {
                stateManager.SetState(prevState);
            }
        }
    }
}

public class Ranged : BehaviourState
{
    public float projectileSpeed = 40;
    public float destroyAfterTime = 0.5f;

    public Ranged(StateManager sm) : base(sm)
    {

    }

    public Ranged(StateManager sm, BehaviourState prev) : base(sm)
    {
        prevState = prev;
    }

    public override void Initialize()
    {

    }

    public override void Update()
    {

    }
}