using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject hud;
    public static int scoreValue = 0;

    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
    }

    public void Update()
    {
        score.text = "" + scoreValue;
    }
}
