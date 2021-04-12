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
    //this will let us store the values from user input
    //in the x and y coor of this 2Directional vector
    public Vector2 movement;
    public bool isMoving;

    //access characterclass so that stamina can be accessed
    public CharacterClass characterClass;

    //These control the stamina display
    public float playerStamina;
    public StaminaSlider staminaDisplay;
    public Image sliderFill;
    public Image sliderBorder;
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
        //both of these return values between -1 and 1, 0 being neutral -1, is down and left, 1 is right and up respectively.

        // assign the Horiz value to Vector2.x (movement.x) - uses Horizontal Unity keyword
        movement.x = Input.GetAxisRaw("Horizontal");
        if (movement.x < 0){ playerSprite.flipX = true; }

        // assig the Vert value to Vector2.y (movement.y) - uses Vertical Unity Keyword
        movement.y = Input.GetAxisRaw("Vertical");

        movingCheck();
        hideStaminaBar();
        
    }

    //this is best used for physics, is called 50times per frame,
    // is further smoothed  by multiplying by Time.fixedDeltaTime
    private void FixedUpdate()
    {
        //acces the MovePosition function in RigidBody2D class. Pass players current position and add the values of our Vector2 that is multiplied by moveSpeed and Time.fixedDeltaTime 
        playerBody.MovePosition(playerBody.position + movement * characterClass.character.minMoveSpeed * Time.fixedDeltaTime);
        sprintCheck();
    }

    void regenStamina()
    {
        if(playerStamina < characterClass.character.maxStamina)
        {
            playerStamina+= Time.fixedDeltaTime*(5+characterClass.character.staminaRegenRate); // add stamina regen property to character
            staminaDisplay.setStamina(playerStamina);
        }
    }

    void sprintCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isMoving && playerStamina > 0)
        {
            playerBody.MovePosition(playerBody.position + movement * characterClass.character.MoveSpeed * Time.fixedDeltaTime);
            playerStamina -= (characterClass.character.staminaBurnRate / 2);
            staminaDisplay.setStamina(playerStamina);
        }
        else if (!isMoving && Input.GetKey(KeyCode.LeftShift))
        {
            regenStamina();
        }
        else
        {
            regenStamina();
        }
    }

    void hideStaminaBar()
    {
        if (staminaDisplay.GetComponentInParent<Slider>().value == staminaDisplay.GetComponentInParent<Slider>().maxValue)
        {
            sliderFill.enabled = false;
            sliderBorder.enabled = false;
        }
        else if (staminaDisplay.GetComponentInParent<Slider>().value != staminaDisplay.GetComponentInParent<Slider>().maxValue)
        {
            sliderFill.enabled = true;
            sliderBorder.enabled = true;
        }
    }

    void movingCheck()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void cacheRefs()
    {
        //assign the RigidBody2D, sprite, class, stamindabar, access player stamina
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        characterClass = GetComponent<CharacterClass>();
        staminaDisplay = FindObjectOfType<StaminaSlider>();
        playerStamina = characterClass.character.maxStamina;

        //set the stamina bar to display the maximum player stamina
        staminaDisplay.setMaxStamina(playerStamina);
    }
}
