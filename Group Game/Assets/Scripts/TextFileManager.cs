using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class TextFileManager
{
    public string logName;
    public string[] logContents;
    /// <summary>
    /// This funciton will be given the name of a file and check if the file already exists, if it doesn't then it will create it
    /// </summary>
    public void CreateFile(string fileName)
    {
        string dirPath = Application.dataPath + "/Resources/" + fileName + ".txt";
        if(File.Exists(dirPath) == false)
        {
            Directory.CreateDirectory(Application.dataPath + "/Resources");
            File.WriteAllText(dirPath, fileName + "\n");
        }
    }
    /// <summary>
    /// This function will read the contents of a file and the return an array of strings
    /// </summary>
    public string[] ReadFileContents(string fileName)
    {
        string dirPath = Application.dataPath + "/Resources/" + fileName + ".txt";
        string[] tContents = new string[0];
        if(File.Exists(dirPath) == true)
        {
            tContents = File.ReadAllLines(dirPath);
        }
        logContents = tContents;
        return tContents;
    }
    /// <summary>
    /// This function will read from a file and maniplulate the logContents variable and then write the variable back to the file
    /// </summary>
    public void AddFileLine(string fileName, string fileContents)
    {
        ReadFileContents(fileName);
        string dirPath = Application.dataPath + "/Resources/" + fileName + ".txt";
        string tContents = fileContents + "\n";
        string timeStamp = "Time Stamp: " + System.DateTime.Now;
        if(File.Exists(dirPath) == true)
        {
            File.AppendAllText(dirPath, timeStamp + " - " + tContents);
        }
    }
    /// <summary>
    /// This function will save a value to the text file and store it using a key
    /// this key can be used to look up the information
    /// </summary>
    public void AddKeyValuePair(string fileName, string key, string value)
    {
        ReadFileContents(fileName);
        string dirPath = Application.dataPath + "/Resources/" + fileName + ".txt";
        string tContents = key + "," + value;
        string timeStamp = "Time Stamp: " + System.DateTime.Now;
        if(File.Exists(dirPath) == true)
        {
            bool contentsFound = false;
            for(int i = 0; i < logContents.Length; i++)
            {
                if(logContents[i].Contains(key) == true)
                {
                    logContents[i] = timeStamp = " - " + tContents;
                    contentsFound = true;
                }
            }

            if (contentsFound == true)
            {
                File.WriteAllLines(dirPath, logContents);
            }
            else
            {
                File.AppendAllText(dirPath, timeStamp + " - " + tContents + "\n");
            }
        }
    }
    /// <summary>
    /// This function will read the file and locate specific values
    /// </summary>
    public string LocateStringByKey(string key)
    {
        ReadFileContents(logName);
        string t = "";
        foreach (string s in logContents)
        {
            if (s.Contains(key) == true)
            {
                string[] splitString = s.Split(",".ToCharArray());
                t = splitString[splitString.Length - 1];
            }
        }
        return t;
    }
    /// <summary>
    /// This function will call the CreateFile function and call the readFileContents function
    /// </summary>
    public void Start()
    {
        CreateFile(logName);
        ReadFileContents(logName);
    }
}
