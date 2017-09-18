using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector3 Mover = new Vector3(0.1f,0,0);

    Rigidbody2D myRigidBody;

    [SerializeField]
    float movementSpeed = 1;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Called from Start.");
        // Teleports game object
        // transform.position = new Vector3(0,0,0);

        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {


        float horizontalInput = Input.GetAxis("Horizontal");

        Debug.Log("Horizontal Input: " + horizontalInput);


        //transform.Translate(Mover);
        /*
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Mover);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Mover);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Mover);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1 * Mover);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0,5,0);
        }
        */
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(0, 5, 0);
        }

        // transform.Translate(0.1f * horizontalInput, 0, 0);

        myRigidBody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidBody.velocity.y);
        
	}
}
