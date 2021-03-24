using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // declare variables
   [Range(0.1f,7.0f)]

    public float moveSpeed;

    public Rigidbody2D playerBody;

    Vector2 movement;

    private void Awake()
    {
        moveSpeed = 1;
        playerBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        print(moveSpeed);
    }

    private void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position+ movement*moveSpeed*Time.fixedDeltaTime);
        
    }


}
