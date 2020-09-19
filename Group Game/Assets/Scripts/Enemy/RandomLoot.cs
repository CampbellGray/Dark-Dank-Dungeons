using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public List<GameObject> items;
    public int[] table = { 60, 30, 10 };
    public Transform itemSpawnLoc;

    public int total;
    public int randomNumber;
    public void GetRandomItem()
    {
        foreach(var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        for(int i = 0; i < table.Length; i++)
        {
            if(randomNumber <= table[i])
            {
                Debug.Log("Award " + table[i]);
                Instantiate(items[i], itemSpawnLoc.position, itemSpawnLoc.rotation);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}
