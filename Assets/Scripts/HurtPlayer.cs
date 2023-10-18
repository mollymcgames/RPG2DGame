using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private float waitToLoad = 1f; //modify this to change the time it takes to reload the scene
    public bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reloading)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load the current scene
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            Debug.Log("Player hit");
            other.gameObject.SetActive(false);

            // SceneManager.LoadScene("Test")
            //TODO: Add a game over screen
            // SceneManager.LoadScene("GameOver")
            // SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

            reloading = true;        

        }
    }
}
