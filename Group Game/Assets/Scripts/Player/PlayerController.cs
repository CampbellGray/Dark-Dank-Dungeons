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
    public Animator movement;

    private HashIDs hash;

    //bool isGrounded;
    Vector3 velocity;

    private void Awake()
    {
        movement = GameObject.FindGameObjectWithTag("Character").GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HashIDs>();
    }

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

        if(x!=0 || z!=0)
        {
            movement.SetBool(hash.walkingBool, true);
        }
        else
        {
            movement.SetBool(hash.walkingBool, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(other.gameObject.tag == "EnemyAttack")
        {
            other.GetComponentInParent<StateManager>().Attack();
            GetComponent<UI>().ApplyDamage();
        }
    }
}
