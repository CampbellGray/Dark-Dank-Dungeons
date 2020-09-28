using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    public GameObject name;
    public string username;

    private void Update()
    {
        username = name.GetComponent<InputField>().text;
    }

    public void GamePlay()
    {
        PlayerPrefs.SetString("username", username);
        
    }
}
