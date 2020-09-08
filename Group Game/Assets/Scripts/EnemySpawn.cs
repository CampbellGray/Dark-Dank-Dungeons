using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemySpawnLoc1;

    public void EnemySpawner()
    {
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnLoc1.transform.position, enemySpawnLoc1.transform.rotation);
        enemy.transform.parent = this.gameObject.transform;
    }
}
