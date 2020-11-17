using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTransitions : MonoBehaviour
{
    public Text text;
    public Animator anim;
    public float transitionDelayTime = 1.0f;

    /// <summary>
    /// This will load the next scene in the game
    /// </summary>
    public void PlayGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 1)
        {
            Score.scoreValue = 0;
        }

        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
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

    public IEnumerator DelayLoadLevel(int index)
    {
        anim.SetTrigger("Transition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}
