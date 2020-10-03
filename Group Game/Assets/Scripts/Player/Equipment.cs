using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public ArmourData data;

    public PlayerData playerData;

    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();
    }

    /// <summary>
    /// if the player is inside of the collider and press E it will call the "Equiparmour" function from the equipment manager script
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            if (Input.GetKeyDown(KeyCode.E) == true)
            {
                Inventory inv = other.GetComponent<Inventory>();
                if (inv.items.AddNode(new BinaryNode.BinaryNode_Item(this, data.index)) == true)
                {
                    inv.TraverseItems(inv.items.root);
                    other.GetComponent<EquipmentManager>().EquipArmour(this);
                    this.gameObject.transform.parent = playerData.gameObject.transform;
                    Debug.Log(this.data.index);
                }
                else 
                {
                    other.GetComponent<EquipmentManager>().EquipArmour(this);
                    this.gameObject.transform.parent = playerData.gameObject.transform;
                }
            }
        }
    }
}

public enum ArmourType { none, helmet, chest, staff }
/// <summary>
/// this sets values that all equipment will have
/// </summary>
[System.Serializable]
public struct ArmourData
{
    public ArmourType type;
    public string name;
    public float bonus;
    public int index;
}