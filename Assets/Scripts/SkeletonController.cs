using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    
    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange  = 0f;
    [SerializeField]
    private float minRange = 0f;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = Object.FindFirstObjectByType<PlayerController>().transform;  //FindObjectOfType is obsolete
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", target.position.x - transform.position.x);
        myAnim.SetFloat("moveY", target.position.y - transform.position.y);        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //work out difference between weapon transform and the enemy transform
        if (other.gameObject.tag == "DamageArea")
        {
            Vector2 difference = transform.position - other.transform.position; //enemy position - weapon position
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }    
}
