using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeShootingDamage : MonoBehaviour
{
    [HideInInspector]
    public float enemyHealth;


    private void Start()
    {
        enemyHealth = GetComponent<EnemyClass>().enemyCharacter.maxHealth;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "PlayerProjectile")
        {
            takeDamage(collision.gameObject.GetComponent<ProjectileClass>().projectileDamage);
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.GetComponent<ProjectileClass>().projectileDamage +enemyHealth);
            Debug.Log("enemy shot");
        }
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

