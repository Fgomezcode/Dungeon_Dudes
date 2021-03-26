using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    /*this script will instance a PREFAB projectile 
     * and fire it towards the position of the player at the 
     * time of instance, 
     * projectile life is how long before projectile is destroyed.
     * possibly refactor how the projectile gets its properties from class.
     * FG 3/26
     */

    GameObject target;
    Rigidbody2D projectileBody;

    private float projectileSpeed;
    public float projectileLife;
    void Start()
    {
        projectileSpeed = GameObject.FindObjectOfType<EnemyClass>().enemyCharacter.projectileSpeed;
        projectileLife = GameObject.FindObjectOfType<EnemyClass>().enemyCharacter.projectileLife;
        target = GameObject.FindGameObjectWithTag("Player");

        projectileBody = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * projectileSpeed;
        projectileBody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, projectileLife);
    }   

  
}
