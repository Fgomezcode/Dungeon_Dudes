using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    GameObject dodgeParticleSystem;

    public float dodgeColliderRange;
    public LayerMask dodgeLayer;
    
    Movement playerMovement;
    PlayerStamina stamina;
    CharacterClass characterClass;

    public float startDodgeTimer;
    public float dodgeTimer;

    void Start()
    {
        cacheRefs();
    }

    void cacheRefs()
    {
        playerMovement = GetComponent<Movement>();
        stamina = GetComponent<PlayerStamina>();
        characterClass = GetComponent<CharacterClass>();
        dodgeParticleSystem = transform.GetChild(2).gameObject;
    }
    public void playerDodge()
    {
        if(dodgeTimer <=0 ) // if player has not dodged
        {   
            dodgeCheck();
            Color temp = GetComponent<SpriteRenderer>().color;
            temp.a = 1f;
            GetComponent<SpriteRenderer>().color = temp;

        }
        else
        {
           
            dodgeTimer -= Time.deltaTime;
           
            Color temp = GetComponent<SpriteRenderer>().color;
            temp.a = .45f;
            GetComponent<SpriteRenderer>().color = temp;
        }
    }

    public void dodgeCheck()
    {
        cardinalDodge();
        diagonalDodge();
    }

    void dodgeExtras( )
    {

       
        dodgeTimer = startDodgeTimer;
        dodgeParticle();

       

        if(playerMovement.movement.x != 0 && playerMovement.movement.y != 0 )
        {
            stamina.staminaCost(characterClass.character.staminaDodgeCost/3);
        }
        else
        {
            stamina.staminaCost(characterClass.character.staminaDodgeCost);
        }

    }

    void dodgeParticle()
    {
        dodgeParticleSystem.GetComponent<PlayParticle>().particlePlay();
    }


    void cardinalDodge()
    {
        //right dodge
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.x > 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x + characterClass.character.dodgeDistance, transform.position.y);
        }
        //left dodge
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.x < 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x - characterClass.character.dodgeDistance, transform.position.y);
        }
        //up dodge
        //left dodge
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.y > 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x, transform.position.y + characterClass.character.dodgeDistance);
        }
        //down dodge
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.y < 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x, transform.position.y - characterClass.character.dodgeDistance);
        }
    }
    void diagonalDodge()
    {
        //upright
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.x > 0 && playerMovement.movement.y > 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x + (characterClass.character.dodgeDistance / 5), transform.position.y + (characterClass.character.dodgeDistance / 5));
        }
        //down right
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.x > 0 && playerMovement.movement.y < 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x + (characterClass.character.dodgeDistance / 5), transform.position.y - (characterClass.character.dodgeDistance / 5));
        }
        //up left
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.x < 0 && playerMovement.movement.y > 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x - (characterClass.character.dodgeDistance / 5), transform.position.y + (characterClass.character.dodgeDistance / 5));
        }
        //down left
        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.movement.x < 0 && playerMovement.movement.y < 0 && stamina.playerStamina > characterClass.character.staminaDodgeCost)
        {
            dodgeExtras();
            transform.position = new Vector2(transform.position.x - (characterClass.character.dodgeDistance / 5), transform.position.y - (characterClass.character.dodgeDistance / 5));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dodgeColliderRange);
    }
}
