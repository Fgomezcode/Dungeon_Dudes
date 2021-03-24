using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the player movement in horizontal and vertical
 * directions, it also controls the speed at which the player moves.
 * 
 * This script should only control movement, write new script
 * for jump or other actions
 * 
 */

public class Movement : MonoBehaviour
{
    /*set the min and max speed for player
     displays in editor so you can change it
     without having to go into the code */
   [Range(0.1f,10.0f)]
    public float moveSpeed;

    //this is the player body
    public Rigidbody2D playerBody;

    //this will let us store the values from user input
    //in the x and y coor of this 2Directional vector
    Vector2 movement;

    //This function finds the RigidBody2D of the object this 
    //script is attached to as soon as the object is spawned.
    //****MUST BE ATTACHED TO THE PRIME PARENT OBJECT****
    private void Awake()
    {
        //assign the RigidBody2D
        playerBody = GetComponent<Rigidbody2D>();
    }

    //this is best used for user input, is framerate dependent.
    void Update()
    {
        //both of these return values between -1 and 1, 0 being neutral -1, is down and left, 1 is right and up respectively.

        // assign the Horiz value to Vector2.x (movement.x) - uses Horizontal Unity keyword
        movement.x = Input.GetAxisRaw("Horizontal");

        // assig the Vert value to Vector2.y (movement.y) - uses Vertical Unity Keyword
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //this is best used for physics, is called 50times per frame,
    // is further smoothed  by multiplying by Time.fixedDeltaTime
    private void FixedUpdate()
    {
        //acces the MovePosition function in RigidBody2D class. Pass players current position and add the values of our Vector2 that is multiplied by moveSpeed and Time.fixedDeltaTime 
        playerBody.MovePosition(playerBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
