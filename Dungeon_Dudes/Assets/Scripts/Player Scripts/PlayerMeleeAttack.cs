using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    private Animator animator;

    public Transform meleePoint;
    public float attackRange;

    

    [Header("Layers to check for collisions")]
    public LayerMask collisionLayers;

    CharacterClass character;
    PlayerStamina playerStamina;
    public float setTimeBetweenAttack;
    public float timeBetweenAttack;
    
    void Start()
    {
        cacheStats();
    }

    // Update is called once per frame
    void Update()
    {
        attackCheck();
    }

    //attacking enemies cost less stamina than breaking a wall, breaking a wall cost major stamina.
    void attack()
    {
        animator.SetTrigger("warriorAttack");
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(meleePoint.position, attackRange,collisionLayers);

        foreach (Collider2D hitObject in hitObjects)
        {
            EnemyTakeDamage hitEnemy = hitObject.GetComponent<EnemyTakeDamage>();
            Wallbreak hitWall = hitObject.GetComponent<Wallbreak>();
            if (hitEnemy)
            { 
                hitEnemy.takeDamage(character.character.meleeDamage);
                playerStamina.staminaCost(character.character.meleeStaminaCost);
            }

            if (hitWall && playerStamina.playerStamina > character.character.maxStamina / 2)
            {
                hitWall.wallDamage(character.character.meleeDamage);
                playerStamina.staminaCost(character.character.meleeWallBreakCost);
            }
            else 
            {
                
            }
        }
        playerStamina.staminaCost(character.character.meleeStaminaCost);
    }

    void attackCheck()
    {

        if (Input.GetButtonDown("Fire1") && Input.GetButton("Fire2"))
        {
            return;
        }
        else if (Input.GetButtonDown("Fire1") && timeBetweenAttack <= 0 && playerStamina.playerStamina > 1 )
        {
            attack();
            timeBetweenAttack = setTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
            if (timeBetweenAttack <= -1)
            {
                timeBetweenAttack = -0.1f;
            }
        }
    }

    void cacheStats()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterClass>();
        setTimeBetweenAttack = character.character.meleeDelay;
        playerStamina = GetComponent<PlayerStamina>();
    }

    private void OnDrawGizmosSelected()
    {
        if(meleePoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(meleePoint.position, attackRange);
    }
}


