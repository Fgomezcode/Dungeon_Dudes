using UnityEngine;
using UnityEngine.UI;
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
    [Header("Assigned at runtime")]
    public Rigidbody2D playerBody;

    // access sprite to flip it
    private SpriteRenderer playerSprite;
    private Animator animator;
    //this will let us store the values from user input
    //in the x and y coor of this 2Directional vector
    public Vector2 movement;
    public bool isMoving;

    //access characterclass so that stamina can be accessed
    public CharacterClass characterClass;
    public PlayerStamina stamina;
    public PlayerDodge dodge;
    //These control the stamina display

    //This function finds the RigidBody2D of the object this 
    //script is attached to as soon as the object is spawned.

    //****MUST BE ATTACHED TO THE PRIME PARENT OBJECT****
    private void Awake()
    {
        cacheRefs();
    }

    //this is best used for user input, is framerate dependent.
    void Update()
    {
        flipSprite();
        movingCheck();
        dodge.playerDodge();
    }

    //this is best used for physics, is called 50times per frame,
    // is further smoothed  by multiplying by Time.fixedDeltaTime
    private void FixedUpdate()
    {
        applyMovement();
        stamina.sprintCheck();
    }

    void applyMovement()
    {
        //acces the MovePosition function in RigidBody2D class. Pass players current position and add the values of our Vector2 that is multiplied by moveSpeed and Time.fixedDeltaTime 
        playerBody.MovePosition(playerBody.position + movement * characterClass.character.minMoveSpeed * Time.fixedDeltaTime); 
    }

    void movingCheck()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            isMoving = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isRunning", false);
        }
    }

    //will flip the sprite to point to face the mouse if the player is standing still
    //or will flip it to face movement direction
    void flipSprite()
    {
        //both of these return values between -1 and 1, 0 being neutral -1, is down and left, 1 is right and up respectively.

        // assign the Horiz value to Vector2.x (movement.x) - uses Horizontal Unity keyword
        movement.x = Input.GetAxisRaw("Horizontal");

        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, -3);
        }
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, -3);
        }
        // assig the Vert value to Vector2.y (movement.y) - uses Vertical Unity Keyword
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(!isMoving)
        {
            if(mousePosition.x < gameObject.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, -3);
            }
            if(mousePosition.x > gameObject.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, -3);
            }
        }
    }
    void cacheRefs()
    {
        //assign the RigidBody2D, sprite, class, stamindabar, access player stamina
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        characterClass = GetComponent<CharacterClass>();
        stamina = GetComponent<PlayerStamina>();
        dodge = GetComponent<PlayerDodge>();
    }
}
