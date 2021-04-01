using UnityEngine;

public class PlayerTakeShootingDamage : MonoBehaviour
{
    //This function applies damag when the player is shot, 
    //uses triggers instead of collisions.
    //FG 3/30

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyProjectile")
        {
            damagePlayer(collision.GetComponent<EnemyProjectile>().projectileDamage);
            Destroy(collision.gameObject);
            Debug.Log("Youve been shot "+ collision.GetComponent<EnemyProjectile>().projectileDamage);
        }
    }

    public void damagePlayer(float damage)
    {
        // declare float health assign the value of health that is assigned in PlayerHealth
        // subtract damage from it
        float health = gameObject.GetComponent<PlayerHealth>().health -= damage;

        //console logs when collider is triggered
        Debug.Log("Remaining Health: " + health);

        //this will destroy the player object when health reaches zero
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
