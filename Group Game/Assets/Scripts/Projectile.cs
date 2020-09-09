using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Score score;
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Score.scoreValue += 50;
        }
    }
}
