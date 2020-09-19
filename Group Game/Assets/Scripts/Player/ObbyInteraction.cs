using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObbyInteraction : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(Score.scoreValue >= 500)
                {
                    UI.currentHealth += 1;
                    Score.scoreValue -= 500;
                }
            }
        }
    }
}
