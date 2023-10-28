using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{

    public int currentHealth;

    public bool reloading;
    public float waitToLoad = 2f; //modify this to change the time it takes to reload the scene
    public int maxHealth;
    // Start is called before the first frame update
    private bool flashActive; //whenever the player gets hit, the player flashes
    [SerializeField]
    private float flashLength = 0.5f; //how long the player flashes for when hit
    private SpriteRenderer playerSprite; //the sprite renderer for the player

    [SerializeField]

    private AudioSource hurtSound;
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
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

        if(flashActive)
        {
            StartCoroutine(FlashPlayer());
        }
    }

    IEnumerator FlashPlayer()
    {
        flashActive = false;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f); //set the alpha to 0
        yield return new WaitForSeconds(flashLength * 0.2f); //multiply by 0.2f to make the flash shorter
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f); //set the alpha to 1
    }

    public void HurtPlayer(int damageGiven)
    {
        currentHealth -= damageGiven;
        flashActive = true;

        // Debug.Log("current health" + currentHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        } if (currentHealth == 0 || currentHealth < 0)
        {
            // gameObject.SetActive(false);
            Invoke("ReloadScene", 2f); // Invoke the ReloadScene method after a delay of 2 seconds

            // SceneManager.LoadScene("Test");
        }
        
    }
    // Add this method to reload the scene
    void ReloadScene()
    {
        SceneManager.LoadScene("Test");
    }
}