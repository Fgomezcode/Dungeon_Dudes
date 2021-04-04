using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    /*This script applies damage to the enemy when they collide with the player
     * FG 3/30
     */
    public float enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyClass>().enemyCharacter.maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CharacterClass player = collision.gameObject.GetComponent<CharacterClass>();

        if(player != null)
        {
            takeDamage(player.character.collisionDamage);
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void takeDamage(float damage)
    {

        enemyHealth -= damage;
    }
}
