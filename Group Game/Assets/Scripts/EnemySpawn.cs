using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemySpawnLoc1;
    public Transform enemySpawnLoc2;
    public Transform enemySpawnLoc3;
    public int enemyCount;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public LinkedList<GameObject> Children = new LinkedList<GameObject>();
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        enemy = Instantiate(enemy, enemySpawnLoc1.transform.position, enemySpawnLoc1.transform.rotation);
        Children.AddLast(enemy);
        enemy.transform.parent = gameObject.transform;

        enemy = Instantiate(enemy, enemySpawnLoc2.transform.position, enemySpawnLoc2.transform.rotation);
        Children.AddLast(enemy);
        enemy.transform.parent = gameObject.transform;

        enemy = Instantiate(enemy, enemySpawnLoc3.transform.position, enemySpawnLoc3.transform.rotation);
        Children.AddLast(enemy);
        enemy.transform.parent = gameObject.transform;

        player.GetComponent<PlayerInteraction>().enemySpawn = this.gameObject.GetComponent<EnemySpawn>();

        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        enemyCount = Children.Count;

        if (enemyCount == 0)
        {
            door1.gameObject.SetActive(false);
            door2.gameObject.SetActive(false);
            door3.gameObject.SetActive(false);
            door4.gameObject.SetActive(false);
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        else
        {
            door1.gameObject.SetActive(true);
            door2.gameObject.SetActive(true);
            door3.gameObject.SetActive(true);
            door4.gameObject.SetActive(true);
        }
    }
}
