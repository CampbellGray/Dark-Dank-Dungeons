using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public LevelBuilder levelBuilder;
    public float speed = 12f;

    private Animator anim;

    //bool isGrounded;
    Vector3 velocity;

    private void Start()
    {
        levelBuilder = FindObjectOfType<LevelBuilder>();
        anim = GetComponentInChildren<Animator>();
        anim.SetInteger("Condition", 0);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
