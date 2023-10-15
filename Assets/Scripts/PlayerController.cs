using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D myRB;

    [SerializeField]   //keep the variable private but editable
    private float speed;  //set the player speed

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   //multiply by the speed and time to add speed and time into it 
        myRB.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;   //preset axis to use in unity to pull from the left and right buttons for keys don't need deltatime
        Debug.Log(myRB.velocity);
    }
}
