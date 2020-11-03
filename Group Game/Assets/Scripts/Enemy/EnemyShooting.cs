using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 30f;
    public float destroyAfterTime = 0.5f;
    public StateManager sm;

    public float distance;

    private void Start()
    {
        sm = GetComponent<StateManager>();
    }

    public void Update()
    {
        distance = Vector3.Distance
            (sm.transform.position,
            sm.Target.position);
        if (distance < sm.viewRadius)
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        int fireSpeed = Random.Range(0, 150);

        if (fireSpeed == 1)
        {
            //play shoot animation
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            Destroy(instantiatedProjectile.gameObject, destroyAfterTime);
        }
    }
}
