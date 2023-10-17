using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = Object.FindFirstObjectByType<PlayerController>().transform;  //FindObjectOfType is obsolete
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
