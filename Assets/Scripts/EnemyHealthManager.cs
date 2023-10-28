using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int enemyHealth;
    public int maxHealth;
    public PlayerStats thePlayerStats;


    private bool flashActive; //whenever the player gets hit, the player flashes
    [SerializeField]
    private float flashLength = 0.8f; //how long the player flashes for when hit
    private SpriteRenderer goblinSprite; //the sprite renderer for the player

    // [SerializeField]

    // private AudioSource hurtSound;    
    // Start is called before the first frame update
    void Start()
    {
        goblinSprite = GetComponent<SpriteRenderer>();
        thePlayerStats = FindFirstObjectByType<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
        if(flashActive)
        {
            StartCoroutine(FlashPlayer());
        }        
        
    }

    IEnumerator FlashPlayer()
    {
        flashActive = false;
        goblinSprite.color = new Color(goblinSprite.color.r, goblinSprite.color.g, goblinSprite.color.b, 0f); //set the alpha to 0
        yield return new WaitForSeconds(flashLength * 0.2f); //multiply by 0.2f to make the flash shorter
        goblinSprite.color = new Color(goblinSprite.color.r, goblinSprite.color.g, goblinSprite.color.b, 1f); //set the alpha to 1
    }    

    public void HurtEnemy(int damageToGive)
    {
        enemyHealth -= damageToGive;
        flashActive = true;
        if(enemyHealth <= 0)
        {
            thePlayerStats.GainExperience(1000);
            Destroy(gameObject);
        }
    }
}
