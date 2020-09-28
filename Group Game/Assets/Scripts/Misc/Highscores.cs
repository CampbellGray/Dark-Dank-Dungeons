using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    const string privateCode = "wR283GfVPke7JYTVifNMogqLQWLP6FAUmrLzDxMJ_Y6g";
    const string publicCode = "5f704c6deb371809c44d04b7";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    static Highscores instance;
    DisplayHighscores highscoresDisplay;

    private void Awake()
    {
        instance = this;
        highscoresDisplay = GetComponent<DisplayHighscores>();
    }
    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("upload successful");
            DownloadHighscores();
        }
        else
        {
            Debug.Log("error uploading " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            highscoresDisplay.OnHighScoresDownloaded(highscoresList);
        }
        else
        {
            Debug.Log("error downloading " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        for(int i = 0; i < entries.Length; i++)
        {
            string[] entriesInfo = entries[i].Split(new char[] { '|' });
            string username = entriesInfo[0];
            int score = int.Parse(entriesInfo[1]);
            highscoresList[i] = new Highscore(username,score);
            Debug.Log(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}