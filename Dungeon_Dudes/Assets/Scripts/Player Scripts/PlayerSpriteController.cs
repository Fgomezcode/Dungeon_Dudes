using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{

    /*This script will flip the sprite so that it faces the movement direction
     * it will also flip to face the mouse if the player is not moving.
     */
    Movement playerMovement;
    SpriteRenderer playerSprite;
    GameObject player;
    private void Awake()
    {
        // player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = GetComponent<Movement>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    //CONSTANTLY CHECK IF THE SPRITE SHOULD FLIP
    void Update()
    {
        flip();
    }

    //
    //
    //
    //
    //

    public void flip()
    {
        //IF HORIZONTAL SPEED IS NOT ZERO PLAYER SPRITE WILL FLIP TO FACE CORRECT WAY
        if (playerMovement.movement.x < 0)
        {
            playerSprite.flipX = true;
        }
        else if (playerMovement.movement.x > 0)
        {
            playerSprite.flipX = false;
        }
        //IF THE PLAYER IS NOT MOVING THE PLAYERSPRITE WILL FLIP TO WHERE THE MOUSE IS POINTING
        else
        {
            mouseFlip();
        }
    }

    public void mouseFlip()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < gameObject.transform.position.x)
        {
            playerSprite.flipX = true;

        }
        else if (mousePosition.x > gameObject.transform.position.x)
        {
            playerSprite.flipX = false;
        }
    }
}
