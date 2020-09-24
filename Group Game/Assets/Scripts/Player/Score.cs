using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject hud;
    public static int scoreValue = 0;
    public LogReader scoreReader;

    private List<KeyValuePair<string, int>> scoreList = new List<KeyValuePair<string, int>>();
    private Text score;

    private void Start()
    {
        scoreList.Add(new KeyValuePair<string, int>("PLayer one", 142));
        scoreList.Add(new KeyValuePair<string, int>("PLayer two", 1142));
        scoreList.Add(new KeyValuePair<string, int>("PLayer Three", 15));
        scoreList.Add(new KeyValuePair<string, int>("PLayer four", 12));
        score = GetComponent<Text>();
        SaveScoreList();
    }

    public void Update()
    {
        score.text = "" + scoreValue;
    }

    public void SaveHightScore()
    {
        scoreReader.SaveKeyValuePair("highScore", scoreValue.ToString());
    }

    public void SaveScoreList()
    {
        KeyValuePair<string, int> highestscore = new KeyValuePair<string, int>();
        for(int i = 0; i < scoreList.Count; i++)
        {
            if(scoreList[i].Value > highestscore.Value)
            {
                highestscore = scoreList[i];
            }
            scoreReader.SaveKeyValuePair(scoreList[i].Key, scoreList[i].Value.ToString());
        }
    }
}
