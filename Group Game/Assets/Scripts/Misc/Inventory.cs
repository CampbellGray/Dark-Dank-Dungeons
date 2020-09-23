using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public BinarySearchTree items;

    public void TraverseItems(BinaryNode parent)
    {
        if(parent != null)
        {
            TraverseItems(parent.left);
            BinaryNode.BinaryNode_Item item = parent as BinaryNode.BinaryNode_Item;
            if (item != null)
            {
                Debug.Log(item.data.data.name);
            }
            TraverseItems(parent.right);
        }
    }
}
