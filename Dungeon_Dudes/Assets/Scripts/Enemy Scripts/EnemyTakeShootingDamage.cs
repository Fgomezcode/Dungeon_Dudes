using UnityEngine;

public class EnemyTakeShootingDamage : MonoBehaviour
{
    /*This script detects when an enemy is hit and applies damage 
     * FG 3/30
     */

    [HideInInspector]
    public float enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyClass>().enemyCharacter.maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        //this can be used to check other triggers
    }

    public void takeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

