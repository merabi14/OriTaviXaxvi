using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.2f;
    [SerializeField] float turnSpeed = 3f;
    [SerializeField] float speedUp = 0.5f;
    [SerializeField] float slowDown = 0.05f;
   
    float constMoveSpeed;   
    float forwardMovment;
    float sideMovment;

    private void Start()
    {
        constMoveSpeed = moveSpeed;
    }
    void Update()
    {
        forwardMovment = Input.GetAxisRaw("Vertical") * moveSpeed;
        sideMovment = Input.GetAxisRaw("Horizontal") * turnSpeed;
    }

    private void FixedUpdate()
    {
        if (forwardMovment != 0)
        {
            if (forwardMovment < 0)
            {
                transform.Rotate(0, 0, sideMovment);
            }
            else
            {
                transform.Rotate(0, 0, -sideMovment);
            }
            transform.Translate(0, forwardMovment, 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowDown;
        Debug.Log("We are going slower!!!!");
        Invoke("SetDefaults", 2F);
        if (collision.collider.tag == "Road")
        {
            moveSpeed = constMoveSpeed;
            Debug.Log("We are going on road!!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpeedUp")
        {
            moveSpeed = speedUp;
            Destroy(collision.gameObject);
            Debug.Log("We are going faster!!");
            Invoke("SetDefaults", 2F);
            RandomSpawn.boostDestroyed = true;
        }
        if (collision.tag == "Road")
        {
            moveSpeed = constMoveSpeed;
            Debug.Log("We are going on road!!");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = slowDown;
    }
    void SetDefaults()
    {
        moveSpeed = constMoveSpeed;
    }
}