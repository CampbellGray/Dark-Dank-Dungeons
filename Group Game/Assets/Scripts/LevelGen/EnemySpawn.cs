using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> enemySpawnLoc;
    public List<GameObject> enemies;
    /// <summary>
    /// for every object in the "enemySpawnLoc" list it will spawn in a enemy at their sapwn locations
    /// set the parent to that spawnlocation
    /// disable their navmeshagent
    /// then add them to the "enemies" list
    /// </summary>
    public void EnemySpawner()
    {

        for (int i = 0; i < enemySpawnLoc.Count; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemySpawnLoc[i].position, enemySpawnLoc[i].rotation);
            enemy.transform.parent = enemySpawnLoc[i].transform;
            enemy.GetComponent<NavMeshAgent>().enabled = false;
            enemies.Add(enemy);
        }
    }
    /// <summary>
    /// for each enemy inside the "enemies" list it will reset their position and rotation
    /// then enable the navmeshagent
    /// </summary>
    public void EnemyReposition()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.gameObject.transform.localPosition = new Vector3(0,0,0);
            enemy.gameObject.transform.localRotation = new Quaternion(0,0,0,0);
            enemy.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
