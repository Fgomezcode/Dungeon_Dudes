using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    /*this script will instance a PREFAB projectile 
     * that will be fired towards the position of the player at the 
     * time of instance, 
     * projectile life is how long before projectile is destroyed.
     * possibly refactor how the projectile gets its properties from class.
     * FG 3/26
     */

    GameObject target;
    Rigidbody2D projectileBody;
    EnemyObject enemyCharacter;

    private float projectileSpeed;
    public float projectileLife;
    public float projectileDamage;

    void Start()
    {
        enemyCharacter = FindObjectOfType<EnemyClass>().enemyCharacter;
        projectileSpeed = enemyCharacter.projectileSpeed;
        projectileLife = enemyCharacter.projectileLife;
        projectileDamage = enemyCharacter.projectileDamage;
        target = GameObject.FindGameObjectWithTag("Player");

        shootTowardPlayer();
    } 

    private void shootTowardPlayer()
    {
        projectileBody = GetComponent<Rigidbody2D>();
        Vector2 moveDirection = (target.transform.position - transform.position).normalized * projectileSpeed;
        projectileBody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, projectileLife);
    }
}
