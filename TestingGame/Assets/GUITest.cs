using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITest : MonoBehaviour
{
    public Texture boxBg;

    private void OnGUI()
    {
        //GUI.Box(new Rect((Screen.width - 800) / 2, (Screen.height - 200) / 2, 800, 200), boxBg);
        if (GUI.Button(new Rect(10, 10, (Screen.width - 10), (Screen.height - 10)), "I am a button"))
        {
            Debug.Log("Button has been pressed!");
        }
    }
}
