using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{ 
    /*This script now only handles collisions and calls the damage function from the
     * playerHealth script.
     * FG 4/13
     */
    public PlayerHealth health;
    public HealthSlider healthBar;

    private void Start()
    {
        healthBar = FindObjectOfType<HealthSlider>();
        health = gameObject.GetComponent<PlayerHealth>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyClass enemy = collision.gameObject.GetComponent<EnemyClass>();
        if(enemy != null)
        {
            health.damagePlayer(enemy.enemyCharacter.baseDamage);
            Debug.Log("Collided with enemy");
        }

        EnemyProjectile enemyProjectile = collision.gameObject.GetComponent<EnemyProjectile>();
        if(enemyProjectile)
        {
            enemyProjectile.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(enemyProjectile.gameObject, 0.1f);
            health.damagePlayer(enemyProjectile.projectileDamage);
            Debug.Log("Player shot by enemy" + health);
        }
    }
}
/*this function will apply the damage to player health, which is being referenced
   * from the PlayerHealth script
   * FG 3/25
   */

/*This script detects when an enemy collides with the player and applies appropriate damage
 * FG 3/30
 */
