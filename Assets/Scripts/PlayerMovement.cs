using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector3 Mover = new Vector3(0.1f,0,0);

    Rigidbody2D myRigidBody;

    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    float jumpStrength = 10;

    [SerializeField]
    Transform groundDetectPoint;

    [SerializeField]
    float groundDetectRadius = .2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    private bool isOnGround;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Called from Start.");

        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpDateIsOnGround();
        HandleMovement();
        HandleJump();

    }

    private void UpDateIsOnGround()
    {
        Collider2D[] groundObjects = Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatCountsAsGround);

        isOnGround = groundObjects.Length > 0;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpStrength);
            isOnGround = false;
        }
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Debug.Log("Horizontal Input: " + horizontalInput);

        myRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidBody.velocity.y);
    }
}
