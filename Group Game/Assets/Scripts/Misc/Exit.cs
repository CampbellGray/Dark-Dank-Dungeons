using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Kyana Bowers
    // Dark Dank Dungeons

    private int currentSceneNumber;

    /// <summary>
    /// Sets the current scene number to the active scene's build index.
    /// </summary>
    private void Start()
    {
        currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// If the player touches the exit portal, it checks to see if the active scene
    /// is not the Lava level, and if it is, it loops back to the Sewer level.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (currentSceneNumber == 4)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(currentSceneNumber + 1);
            }
        }
    }
}

