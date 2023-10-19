using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{

    public int currentHealth;

    public bool reloading;
    public float waitToLoad = 1f; //modify this to change the time it takes to reload the scene
    public int maxHealth;
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

    public void HurtPlayer(int damageGiven)
    {
        currentHealth -= damageGiven;
        Debug.Log("current health" + currentHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        } if (currentHealth == 0 || currentHealth < 0)
        {
            // gameObject.SetActive(false);
            SceneManager.LoadScene("Test");
        }
        
    }
}