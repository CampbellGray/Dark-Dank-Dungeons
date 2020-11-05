using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogReader : MonoBehaviour
{
    public TextFileManager fileManager = new TextFileManager();
    /// <summary>
    /// This function will initialize the file manager
    /// </summary>
    private void Start()
    {
        fileManager.Start();
    }
    /// <summary>
    /// This function will save data to the text file manager
    /// </summary>
    public void SaveKeyValuePair(string key, string value)
    {
        fileManager.AddKeyValuePair(fileManager.logName, key, value);
    }
    /// <summary>
    /// this function will return the result of the LocateStringByKey function
    /// </summary>
    public string LoadStringByKey(string key)
    {
        return fileManager.LocateStringByKey(key);
    }
    /// <summary>
    /// This function will extract a float from the text file
    /// </summary>
    public float LoadFloatByKey(string key)
    {
        float f = 0;
        float.TryParse(fileManager.LocateStringByKey(key), out f);
        return f;
    }
    /// <summary>
    /// This function will extract a integer from the text file
    /// </summary>
    public int LoadIntByKey(string key)
    {
        int i = 0;
        int.TryParse(fileManager.LocateStringByKey(key), out i);
        return i;
    }
    /// <summary>
    /// This function will extract a bool from the text file
    /// </summary>
    public bool LoadBoolByKey(string key)
    {
        string v = fileManager.LocateStringByKey(key);
        if(v == "True" || v == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
