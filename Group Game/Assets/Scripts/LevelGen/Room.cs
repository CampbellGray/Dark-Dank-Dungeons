using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Doorway[] doorways;
    public MeshCollider meshCollider;
    /// <summary>
    /// this will return the mesh colliders bounds
    /// </summary>
    public Bounds RoomBounds
    {
        get { return meshCollider.bounds; }
    }
}
