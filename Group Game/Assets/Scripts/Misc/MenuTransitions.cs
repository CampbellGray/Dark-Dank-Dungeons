using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTransitions : MonoBehaviour
{
    /// <summary>
    /// This will load the next scene in the game
    /// </summary>
    /// 
    public void PlayGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        Score.scoreValue = 0;
    }

    /// <summary>
    /// This will close the game 
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// this will take you back to the main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
