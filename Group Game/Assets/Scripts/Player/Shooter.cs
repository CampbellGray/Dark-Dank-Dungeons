﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 40f;
    public float manaRegenSpeed = 0.5f;
    public UI ui;
    public Animator attack;

    public EquipmentManager equipmanager;
    public Equipment equipment;

    public AudioSource audioSource;
    public AudioClip fire;

    private HashIDs hash;

    private void Awake()
    {
        ui = GetComponentInParent<UI>();
        attack = GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HashIDs>();
        equipmanager = GetComponent<EquipmentManager>();
        equipment = GetComponent<Equipment>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(ui.currentMana > ui.maxMana)
        {
            ui.currentMana = ui.maxMana;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(ui.currentMana > 1)
            {
                attack.SetTrigger(hash.attackTringger);
                ui.currentMana -= 1;
                audioSource.PlayOneShot(fire, 0.7f);
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
                GameObject.Destroy(instantiatedProjectile.gameObject, 5f);
            }
        }

        ui.currentMana += manaRegenSpeed * Time.deltaTime;
    }
}
