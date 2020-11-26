﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectileSound;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Wall")
        {
            GameObject proj = Instantiate(projectileSound, transform.position, transform.rotation);
            Destroy(proj, 5f);
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject proj = Instantiate(projectileSound, transform.position, transform.rotation);
            Destroy(proj, 5f);
            gameObject.SetActive(false);
            Destroy(this.gameObject);           
            Score.scoreValue += 50;
        }
    }
}
