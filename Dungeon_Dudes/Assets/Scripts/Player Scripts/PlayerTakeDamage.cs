using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    /*this function will apply the damage to player health, which is being referenced
     * from the PlayerHealth script
     * FG 3/25
     */

    // simple collider check- applies two damage anytime it collides with anything
    //testing purposes only

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //damagePlayer(2);

        EnemyClass enemy = collision.GetComponent<EnemyClass>();
        if(enemy != null)
        {
            damagePlayer(enemy.enemyCharacter.baseDamage);
            Debug.Log("Collided with enemy");
        }
    }

    //This function will subtract 'damage' from player health every time it is called
    public void damagePlayer(float damage)
    {
        // declare float health assign the value of health that is assigned in PlayerHealth
        // subtract damage from it
        float health = gameObject.GetComponent<PlayerHealth>().health -= damage;

        //console logs when collider is triggered
        Debug.Log("player trigger" + health);

        //this will destroy the player object when health reaches zero
        if (health <= 0)
        {
            Destroy(gameObject);
            
        }

    }


}


