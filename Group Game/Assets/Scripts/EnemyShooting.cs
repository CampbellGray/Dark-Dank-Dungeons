using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 40f;
    public float destroyAfterTime = 0.5f;

    public void Shoot()
    {
        int fireSpeed = Random.Range(0, 10);

        if (fireSpeed == 1)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            Destroy(instantiatedProjectile.gameObject, destroyAfterTime);
        }
    }
}
