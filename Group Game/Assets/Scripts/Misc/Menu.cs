using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool manuState = true;
    public GameObject mainMenu;
    public GameObject leaderboard;
    private void Update()
    {
        if(manuState == true)
        {
            mainMenu.SetActive(true);
            leaderboard.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(false);
            leaderboard.SetActive(true);
        }
    }

    public void manuBoolTrue()
    {
        manuState = true;
    }

    public void manuBoolFalse()
    {
        manuState = false;
    }
}
