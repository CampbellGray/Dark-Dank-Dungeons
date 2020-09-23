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
    /// <summary>
    /// This function will set the variable "total" to the total number of objects in the list "items"
    /// then it will set "randomNumber" to a random number between 0 and the variable "total"
    /// then it will check every number in the list "table" if the number is less than or equal to the number that "randomNumber" is set to
    /// if it is then it will instantiate the item
    /// if it isnt then it will remove that number from the list "table" from "randomNumber" and then check again
    /// </summary>
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
                Instantiate(items[i], itemSpawnLoc.position, Quaternion.Euler(-90,0,-180));
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}
