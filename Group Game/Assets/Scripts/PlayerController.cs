using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Created by David Borger
    // Based off this online tutorial https://www.youtube.com/watch?v=_QajrabyTJc&t= 
    public CharacterController controller;
    public LevelBuilder levelBuilder;

    public float speed = 12f;
    public float gravity = -9;
    public float jumpHeight = 3f;

    //public Transform groundCheck;
    //public float groundDistance = 0.4f;
    //public LayerMask groundMask;

    //bool isGrounded;
    Vector3 velocity;

    private void Start()
    {
        levelBuilder = FindObjectOfType<LevelBuilder>();
    }

    /// <summary>
    /// This creates functionality for the player movement/jumping on the WASD and spacebar,
    /// as well the handling of gravity of the player.
    /// </summary>
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            levelBuilder.GetComponent<LevelBuilder>().ResetLevelGenerator();
        }
    }
}
