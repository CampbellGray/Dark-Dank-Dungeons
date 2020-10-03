using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObbyInteraction : MonoBehaviour
{

    public static int obbyPrice = 500;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(Score.scoreValue >= obbyPrice)
                {
                    UI.currentHealth = UI.healthCap;
                    Score.scoreValue -= obbyPrice;
                    obbyPrice += 500;
                }
            }
        }
    }
}
