using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform playerObj;
    public EnemySpawn enemySpawn;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (Physics.Raycast(playerObj.transform.position, playerObj.transform.forward, out RaycastHit hit, 2.5f))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    Destroy(hit.collider.gameObject);
                    enemySpawn.Children.Remove(hit.collider.gameObject);
                    Debug.DrawRay(playerObj.transform.position, playerObj.transform.forward * 2.5f, Color.green, 0.2f);
                }
                else
                {
                    Debug.DrawRay(playerObj.transform.position, playerObj.transform.forward * 2.5f, Color.red, 0.2f);
                }
            }
            else
            {
                Debug.DrawRay(playerObj.transform.position, playerObj.transform.forward * 2.5f, Color.red, 0.2f);
            }
        }
    }
}
