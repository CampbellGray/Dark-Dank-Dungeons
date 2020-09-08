using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Doorway[] doorways;
    public MeshCollider meshCollider;
    //public Transform[] enemySpawn;

    public Bounds RoomBounds
    {
        get { return meshCollider.bounds; }
    }
}
