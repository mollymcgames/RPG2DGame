using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSkeleton : MonoBehaviour
{
    public int damageToGive = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Skeleton")
        {
            SkeletonHealthManager skeletonHealthManager = other.gameObject.GetComponent<SkeletonHealthManager>();
            skeletonHealthManager.HurtEnemy(damageToGive);
        }
    }
}
