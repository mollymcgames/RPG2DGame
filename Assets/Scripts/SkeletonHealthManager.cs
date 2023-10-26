using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHealthManager : MonoBehaviour
{
    public int skeletonHealth;
    public int maxHealth;


    private bool flashActive; //whenever the player gets hit, the player flashes
    [SerializeField]
    private float flashLength = 0.8f; //how long the player flashes for when hit
    private SpriteRenderer skeletonSprite; //the sprite renderer for the player

    // Start is called before the first frame update
    void Start()
    {
        skeletonSprite = GetComponent<SpriteRenderer>();

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
        skeletonSprite.color = new Color(skeletonSprite.color.r, skeletonSprite.color.g, skeletonSprite.color.b, 0f); //set the alpha to 0
        yield return new WaitForSeconds(flashLength * 0.2f); //multiply by 0.2f to make the flash shorter
        skeletonSprite.color = new Color(skeletonSprite.color.r, skeletonSprite.color.g, skeletonSprite.color.b, 1f); //set the alpha to 1
    }    

    public void HurtEnemy(int damageToGive)
    {
        skeletonHealth -= damageToGive;
        flashActive = true;
        if(skeletonHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
