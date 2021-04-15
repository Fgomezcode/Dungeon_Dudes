using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallbreak : MonoBehaviour
{
    // Start is called before the first frame update
    public float wallhealth;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //access the players stats
        CharacterClass player = collision.collider.GetComponent<CharacterClass>();
        //access the player current stamina
        Movement movingPlayer = collision.collider.GetComponent <Movement>();
        if (player)
        {   
            //if the player has more than half of their stamina and they are sprinting they 
            //will do 4 times the wall damage, at the cost of half of their current stamina
            if (movingPlayer.playerStamina > (player.character.maxStamina/ 2) && Input.GetKey(KeyCode.LeftShift))
            {
                movingPlayer.playerStamina -= (movingPlayer.playerStamina*0.5f);
                wallhealth -= (player.character.collisionDamage *4);
                //console log info
                Debug.Log("Wall took sprint damage hit!!");
            }
            //if the player walks into a wall the wall will break after appropriate number of bumps
            //this will be replaced with melee attack instead of bump
           // wallhealth -= player.character.collisionDamage;
            //Debug.Log("Wall hit!!");
            
            //just to check collision
            Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
            tempColor.a = 0.85f;
            //gameObject.GetComponent<SpriteRenderer>().color = tempColor;
        }

        //this is if the player shoots the wall
        //cache ref to projectile class
        ProjectileClass playerProjectile = collision.collider.GetComponent<ProjectileClass>();
        if (playerProjectile)
        {
            //wall health will take 1/4 the damage of the players ranged attack
            wallhealth -= (playerProjectile.projectileDamage*.25f);

            //projectile class will handle the destroy and enabling of components

 
            //this is purely for visual feedback so the player knows that the projectile missed
            Debug.Log("player shot wall!!");
        }

        //this is if the enemy shoots the walls.
        EnemyProjectile enemyProjectile = collision.collider.GetComponent<EnemyProjectile>();
        if(enemyProjectile)
        {
            wallhealth -= (enemyProjectile.projectileDamage / 2);
            //turn of collider -- same as above
            collision.collider.GetComponent<CircleCollider2D>().enabled = false;
            // projectile will delay before being destroyed -- same as above
            Destroy(collision.gameObject, .175f);
            Debug.Log("Wall shot by enemy!!");
        }

    }

   
    // Update is called once per frame
    void Update()
    {
        destroyWall();
    }

    //this function destroys the wall when it has no health remaining
    void destroyWall()
    {
        if (wallhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void wallDamage(float damage)
    {
        wallhealth -= damage;
        destroyWall();
    }
}
