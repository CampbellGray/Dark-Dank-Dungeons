using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public LevelBuilder levelBuilder;
    public float speed = 12f;
    public Animator movement;
    public GameObject text;
    public PlayerData playerData;

    private HashIDs hash;

    //bool isGrounded;
    Vector3 velocity;

    private void Awake()
    {
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            if(SceneManager.GetActiveScene().buildIndex == 4)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                for(int i = 0; i < playerData.transform.childCount; i++)
                {
                    var child = playerData.transform.GetChild(i).gameObject;
                    if(child != null)
                    {
                        child.SetActive(false);
                    }
                }
            }

        }
        else if(other.gameObject.tag == "EnemyAttack")
        {
            other.GetComponentInParent<StateManager>().Attack();
            GetComponent<UI>().ApplyDamage();
        }
        if (other.gameObject.tag == "Obby")
        {
            text.GetComponent<TextMesh>().text = "E - Full Health - " + ObbyInteraction.obbyPrice + " Souls";
            text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obby")
        {
            text.gameObject.SetActive(false);
        }
    }
}
