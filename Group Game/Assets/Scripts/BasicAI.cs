using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State { none, wander, patrol, chase }

public class BasicAI : MonoBehaviour
{
    public State initialState;
    public float sprintMultiplyer;
    [Header("Chases Settings")]
    public Transform target;
    public float chaseDistance = 2.5f;
    public AudioClip chaseSound;

    private NavMeshAgent agent;
    private Vector3 targetPos;
    public State currentState = State.none;
    private AudioSource aSrc;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        aSrc = GetComponent<AudioSource>();
    }


    void Start()
    {
        SetState(initialState);
    }

    public void SetState(State s)
    {
        if (currentState != s)
        {
            currentState = s;
            if (currentState == State.wander)
            {
                PlaySound(wanderSound);
                chaseDistance = 0;
                FindNewWanderTarget();
            }
            else if (currentState == State.patrol)
            {
                GotToNextPatrolPoint(randomSequence);
            }
            else if (currentState == State.chase)
            {
                PlaySound(chaseSound);
                chaseDistance = 10;
                Chase();
            }
        }

    }

    void Update()
    {

        float distanceToPlayer = Vector3.Distance(target.position, transform.position);
        if (distanceToPlayer <= chaseDistance)
        {
            if (currentState != State.chase)
            {
                SetState(State.chase);

            }
            else
            {
                agent.SetDestination(target.position);
                
            }
        }
        else
        {
            if (currentState != State.chase)
            {

                float distance = Vector3.Distance(targetPos, transform.position);
                if (distance <= agent.stoppingDistance)
                {
                    agent.isStopped = true;
                    if (currentState == State.wander)
                    {

                        FindNewWanderTarget();
                    }
                    else if (currentState == State.patrol)
                    {
                        GotToNextPatrolPoint(randomSequence);
                    }
                }
            }
            else
            {
                Walk();
                SetState(initialState);
            }

        }



    }

    Vector3 GetRandomPoint()
    {
        float randomX = Random.Range(-boundsBox.extents.x + agent.radius, boundsBox.extents.x - agent.radius);
        float randomZ = Random.Range(-boundsBox.extents.z + agent.radius, boundsBox.extents.z - agent.radius);
        return new Vector3(randomX, transform.position.y, randomZ);
    }

    Vector3 GetPatrolPoint(bool random = false)
    {
        if (random == false)
        {
            if (targetPos == Vector3.zero)
            {
                return patrolPoints[0].position;
            }
            else
            {
                for (int i = 0; i < patrolPoints.Length; i++)
                {
                    if (patrolPoints[i].position == targetPos)
                    {
                        if (i + 1 >= patrolPoints.Length)
                        {
                            return patrolPoints[0].position;
                        }
                        else
                        {
                            return patrolPoints[i + 1].position;
                        }
                    }
                }
            }
        }
        else
        {
            return patrolPoints[Random.Range(0, patrolPoints.Length)].position;
        }

        return targetPos;
    }

    void GotToNextPatrolPoint(bool random = false)
    {
        if (random == false)
        {
            targetPos = GetPatrolPoint();
        }
        else
        {
            targetPos = GetPatrolPoint(true);
        }
        agent.SetDestination(targetPos);
        agent.isStopped = false;
    }

    void FindNewWanderTarget()
    {
        targetPos = GetRandomPoint();
        agent.SetDestination(targetPos);
        agent.isStopped = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boundsBox.center, boundsBox.size);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(targetPos, 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }

    void Chase()
    {
        agent.speed *= sprintMultiplyer;
        agent.SetDestination(target.position);
    }

    void Walk()
    {
        agent.speed /= sprintMultiplyer;
    }

    public State GetCurrentState()
    {
        return currentState;
    }

    public void PlaySound(AudioClip clip, bool oneShot = false)
    {
     if (oneShot == false)
     {
        aSrc.clip = clip;
        aSrc.Play();
     }

    }

}