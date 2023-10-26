using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Loads the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load the next scene in queue
    }

    public void QuitGame()
    {
        // Quits the game
        Debug.Log("Quit");
        Application.Quit();
    }
}
