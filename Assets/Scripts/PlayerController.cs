using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]   //keep the variable private but editable
    private float speed =0f;  //set the player speed

    private float attackTime = 0.3f;
    private float attackTimeCounter = 0.3f;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   //multiply by the speed and time to add speed and time into it 
        myRB.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;   //don't need to use normalized if you don't want to

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);


        //Reset animations
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        }

        if(isAttacking)
        {
            myRB.velocity = Vector2.zero;  //not moving when attacking
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }

        }
        if(Input.GetMouseButton(0)) //check for left click
        {
            attackTimeCounter = attackTime; //make sure when we swing sword, it's not instant
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }
        // private void OnCollisionEnter2D(Collision2D other)
        // {
        //     if (other.gameObject.CompareTag("NPC"))
        //     {
        //         Debug.Log("Player is interacting with the NPC");
        //     }
        // }
}
