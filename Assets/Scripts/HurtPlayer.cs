using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    public float waitToHurt = 2f; //modify this to change the time it takes to reload the scene
    public bool isTouching;
    private HealthManager healthMan;
    [SerializeField]
    private int damageToGive = 10;

    // [SerializeField]
    // private AudioSource hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindFirstObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(reloading)
        // {
        //     waitToLoad -= Time.deltaTime;
        //     if(waitToLoad <= 0)
        //     {
        //         SceneManager.LoadScene(SceneManager.GetActiveScene().name); //load the current scene
        //     }
        // }
        if(isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
                Debug.Log("Player hit");
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 2f;
                // hurtSound.Play(); //Play the hurt sound effect for dying here
                // other.gameObject.SetActive(false);

                // SceneManager.LoadScene("Test")
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            Debug.Log("Player hit");
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            // hurtSound.Play(); //Play the hurt sound effect 
            // other.gameObject.SetActive(false);

            // SceneManager.LoadScene("Test")
            //TODO: Add a game over screen
            // SceneManager.LoadScene("GameOver")
            // SceneManager.LoadScene("GameOver", LoadSceneMode.Single);

            // reloading = true;        
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 1f;
        }
    }
}
