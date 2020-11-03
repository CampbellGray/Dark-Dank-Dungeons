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
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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

    IEnumerator DelayLoadLevel(int index)
    {
        anim.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}
