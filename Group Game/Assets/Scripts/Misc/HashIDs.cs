using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int walkingBool;
    public int attackTringger;

    private void Awake()
    {
        walkingBool = Animator.StringToHash("Walk");
        attackTringger = Animator.StringToHash("Shoot");
    }
}
