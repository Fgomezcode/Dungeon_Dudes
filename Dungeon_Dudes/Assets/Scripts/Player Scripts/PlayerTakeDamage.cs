using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    /*this function will apply the damage to player health, which is being referenced
     * from the PlayerHealth script
     * FG 3/25
     */

    /*This script detects when an enemy collides with the player and applies appropriate damage
     * FG 3/30
     */


    public HealthSlider healthBar;
    private void Start()
    {
        healthBar = FindObjectOfType<HealthSlider>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyClass enemy = collision.gameObject.GetComponent<EnemyClass>();
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
        healthBar.setHealth(health);
        //console logs when collider is triggered
        Debug.Log("player trigger" + health);

        //this will destroy the player object when health reaches zero
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}


