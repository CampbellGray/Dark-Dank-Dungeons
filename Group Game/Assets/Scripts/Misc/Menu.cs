using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public bool manuState = true;
    public GameObject mainMenu;
    public GameObject leaderboard;
    public AudioMixer audioMixer;
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

    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }
}
