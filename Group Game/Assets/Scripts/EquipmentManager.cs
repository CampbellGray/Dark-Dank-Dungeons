using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Transform itemDropLocation;

    public GameObject ironChest;
    public GameObject ironHelmet;
    public GameObject goldenChest;
    public GameObject goldenHelmet;
    public GameObject manaChest;
    public GameObject manaHelmet;
    public GameObject MagmaChest;
    public GameObject MagmaHelmet;

    public Armour currentHelmet;
    public Armour currentChest;

    public void EquipArmour(Armour armour)
    {
        if(armour.data.type == ArmourType.helmet && armour.data.name == "Iron_Helmet")
        {
            SetHelmet(armour);
            ironHelmet.gameObject.SetActive(true);
            GetComponent<UI>().healthCap += currentHelmet.data.lifeBonus;
        }
        else if(armour.data.type == ArmourType.chest && armour.data.name == "Iron_Chest")
        {
            SetChest(armour);
            ironChest.gameObject.SetActive(true);
            GetComponent<UI>().healthCap += currentChest.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Gold_Helmet")
        {
            SetHelmet(armour);
            goldenHelmet.gameObject.SetActive(true);
            GetComponent<UI>().healthCap += currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Gold_Chest")
        {
            SetChest(armour);
            goldenChest.gameObject.SetActive(true);
            GetComponent<UI>().healthCap += currentChest.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Mana_Helmet")
        {
            SetHelmet(armour);
            manaHelmet.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Mana_Chest")
        {
            SetChest(armour);
            manaChest.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentChest.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Magma_Helmet")
        {
            SetHelmet(armour);
            MagmaHelmet.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Magma_Chest")
        {
            SetChest(armour);
            MagmaChest.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentChest.data.lifeBonus;
        }
    }
    public void UnequipArmour(Armour armour)
    {
        if (armour.data.type == ArmourType.helmet && armour.data.name == "Iron_Helmet")
        {
            ironHelmet.gameObject.SetActive(false);
            GetComponent<UI>().healthCap -= currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Iron_Chest")
        {
            ironChest.gameObject.SetActive(false);
            GetComponent<UI>().healthCap -= currentChest.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Gold_Helmet")
        {
            goldenHelmet.gameObject.SetActive(false);
            GetComponent<UI>().healthCap -= currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Gold_Chest")
        {
            goldenChest.gameObject.SetActive(false);
            GetComponent<UI>().healthCap -= currentChest.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Mana_Helmet")
        {
            manaHelmet.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Mana_Chest")
        {
            manaChest.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentChest.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Magma_Helmet")
        {
            MagmaHelmet.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentHelmet.data.lifeBonus;
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Magma_Chest")
        {
            MagmaChest.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentChest.data.lifeBonus;
        }
    }
    private void SetHelmet(Armour helmet)
    {
        if(currentHelmet != null)
        {
            SpawnArmour(currentHelmet);
            UnequipArmour(currentHelmet);
        }
        currentHelmet = helmet;
        helmet.gameObject.SetActive(false);
        
    }

    private void SetChest(Armour chest)
    {
        if (currentChest != null)
        { 
            SpawnArmour(currentChest);
            UnequipArmour(currentChest);
        }
        currentChest = chest;
        chest.gameObject.SetActive(false);
    }

    private void SpawnArmour(Armour armour) 
    {
        armour.gameObject.SetActive(true);
        armour.transform.position = itemDropLocation.transform.position;
        armour.transform.localRotation = new Quaternion(0,0,0,0);
    }
}
