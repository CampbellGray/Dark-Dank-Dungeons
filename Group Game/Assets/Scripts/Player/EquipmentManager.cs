﻿using System.Collections;
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
    public GameObject magmaChest;
    public GameObject magmaHelmet;
    public GameObject greenStaff;
    public GameObject blueStaff;
    public GameObject yellowStaff;
    public GameObject purpleStaff;

    public Equipment currentHelmet;
    public Equipment currentChest;
    public Equipment currentStaff;

    public Shooter shooter;

    private void Start()
    {
        GetComponent<Shooter>();
    }

    public void EquipArmour(Equipment equipment)
    {
        if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Iron_Helmet")
        {
            SetHelmet(equipment);
            ironHelmet.gameObject.SetActive(true);
            UI.healthCap += currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Iron_Chest")
        {
            SetChest(equipment);
            ironChest.gameObject.SetActive(true);
            UI.healthCap += currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Gold_Helmet")
        {
            SetHelmet(equipment);
            goldenHelmet.gameObject.SetActive(true);
            UI.healthCap += currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Gold_Chest")
        {
            SetChest(equipment);
            goldenChest.gameObject.SetActive(true);
            UI.healthCap += currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Mana_Helmet")
        {
            SetHelmet(equipment);
            manaHelmet.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Mana_Chest")
        {
            SetChest(equipment);
            manaChest.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Magma_Helmet")
        {
            SetHelmet(equipment);
            magmaHelmet.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Magma_Chest")
        {
            SetChest(equipment);
            magmaChest.gameObject.SetActive(true);
            GetComponent<UI>().manaCap += currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Green Staff")
        {
            SetStaff(equipment);
            greenStaff.gameObject.SetActive(true);
            shooter.manaRegenSpeed += currentStaff.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Blue Staff")
        {
            SetStaff(equipment);
            blueStaff.gameObject.SetActive(true);
            shooter.manaRegenSpeed += currentStaff.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Yellow Staff")
        {
            SetStaff(equipment);
            yellowStaff.gameObject.SetActive(true);
            shooter.manaRegenSpeed += currentStaff.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Purple Staff")
        {
            SetStaff(equipment);
            purpleStaff.gameObject.SetActive(true);
            shooter.manaRegenSpeed += currentStaff.data.bonus;
        }
    }
    public void UnequipArmour(Equipment equipment)
    {
        if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Iron_Helmet")
        {
            ironHelmet.gameObject.SetActive(false);
            UI.healthCap -= currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Iron_Chest")
        {
            ironChest.gameObject.SetActive(false);
            UI.healthCap -= currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Gold_Helmet")
        {
            goldenHelmet.gameObject.SetActive(false);
            UI.healthCap -= currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Gold_Chest")
        {
            goldenChest.gameObject.SetActive(false);
            UI.healthCap -= currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Mana_Helmet")
        {
            manaHelmet.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Mana_Chest")
        {
            manaChest.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.helmet && equipment.data.name == "Magma_Helmet")
        {
            magmaHelmet.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentHelmet.data.bonus;
        }
        else if (equipment.data.type == ArmourType.chest && equipment.data.name == "Magma_Chest")
        {
            magmaChest.gameObject.SetActive(false);
            GetComponent<UI>().manaCap -= currentChest.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Green Staff")
        {
            greenStaff.gameObject.SetActive(false);
            shooter.manaRegenSpeed -= currentStaff.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Blue Staff")
        {
            blueStaff.gameObject.SetActive(false);
            shooter.manaRegenSpeed -= currentStaff.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Yellow Staff")
        {
            yellowStaff.gameObject.SetActive(false);
            shooter.manaRegenSpeed -= currentStaff.data.bonus;
        }
        else if (equipment.data.type == ArmourType.staff && equipment.data.name == "Purple Staff")
        {
            purpleStaff.gameObject.SetActive(false);
            shooter.manaRegenSpeed -= currentStaff.data.bonus;
        }
    }
    private void SetHelmet(Equipment helmet)
    {
        if(currentHelmet != null)
        {
            SpawnArmour(currentHelmet);
            UnequipArmour(currentHelmet);
        }
        currentHelmet = helmet;
        helmet.gameObject.SetActive(false);
        
    }

    private void SetChest(Equipment chest)
    {
        if (currentChest != null)
        { 
            SpawnArmour(currentChest);
            UnequipArmour(currentChest);
        }
        currentChest = chest;
        chest.gameObject.SetActive(false);
    }
    private void SetStaff(Equipment staff)
    {
        if (currentStaff != null)
        {
            SpawnArmour(currentStaff);
            UnequipArmour(currentStaff);
        }
        currentStaff = staff;
        staff.gameObject.SetActive(false);
    }

    private void SpawnArmour(Equipment armour) 
    {
        armour.gameObject.SetActive(true);
        armour.transform.position = itemDropLocation.transform.position;
        armour.transform.localRotation = Quaternion.Euler(-90,0,-180);
    }
}
