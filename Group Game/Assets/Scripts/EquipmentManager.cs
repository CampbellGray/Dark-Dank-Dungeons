using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
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
            ironChest.gameObject.SetActive(true);
        }
        else if(armour.data.type == ArmourType.chest && armour.data.name == "Iron_Chest")
        {
            SetChest(armour);
            ironHelmet.gameObject.SetActive(true);
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Gold_Helmet")
        {
            SetHelmet(armour);
            goldenHelmet.gameObject.SetActive(true);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Gold_Chest")
        {
            SetChest(armour);
            goldenChest.gameObject.SetActive(true);
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Mana_Helmet")
        {
            SetChest(armour);
            manaHelmet.gameObject.SetActive(true);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Mana_Chest")
        {
            SetHelmet(armour);
            manaChest.gameObject.SetActive(true);
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Magma_Helmet")
        {
            SetChest(armour);
            MagmaHelmet.gameObject.SetActive(true);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Magma_Chest")
        {
            SetChest(armour);
            MagmaChest.gameObject.SetActive(true);
        }
    }

    public void UnequipArmour(Armour armour)
    {
        if (armour.data.type == ArmourType.helmet && armour.data.name == "Iron_Helmet")
        {
            ironChest.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Iron_Chest")
        {
            ironHelmet.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Gold_Helmet")
        {
            goldenHelmet.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Gold_Chest")
        {
            goldenChest.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Mana_Helmet")
        {
            manaHelmet.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Mana_Chest")
        {
            manaChest.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.helmet && armour.data.name == "Magma_Helmet")
        {
            MagmaHelmet.gameObject.SetActive(false);
        }
        else if (armour.data.type == ArmourType.chest && armour.data.name == "Magma_Chest")
        {
            MagmaChest.gameObject.SetActive(false);
        }
    }

    private void SetHelmet(Armour helmet)
    {
        if(currentHelmet != null)
        {
            SpawnArmour(currentHelmet);
            helmet.gameObject.SetActive(false);
            UnequipArmour(currentHelmet);
            GetComponent<UI>().manaCap -= currentHelmet.data.lifeBonus;
        }
        currentHelmet = helmet;
        Destroy(helmet);
        GetComponent<UI>().manaCap += currentHelmet.data.lifeBonus;
    }

    private void SetChest(Armour chest)
    {
        if (currentChest != null)
        {
            SpawnArmour(currentChest);
            chest.gameObject.SetActive(false);
            UnequipArmour(currentChest);
            GetComponent<UI>().manaCap -= currentChest.data.lifeBonus;
        }
        currentChest = chest;
        chest.gameObject.SetActive(true);
        GetComponent<UI>().manaCap += currentChest.data.lifeBonus;
    }

    private void SpawnArmour(Armour armour) 
    {
        armour.transform.SetParent(null);
        armour.GetComponent<Collider>().enabled = true;
    }
}
