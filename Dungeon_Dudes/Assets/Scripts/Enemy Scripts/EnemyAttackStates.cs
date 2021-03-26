using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackStates : MonoBehaviour
{
    /* this needs to be refactored
     * to use ontrigger2d enter/exit
     * FG 3/26
     */
    [Header("Enemy Move Speed")]
    private float moveSpeed;

    [Header("Check To Make Ranged Enemy")]
    private bool canShoot;

    [Header("Ranged Settings")]
    [Tooltip("If player crosses this line the enemy chases them")]
    public float lineOfsight;
    public float aggroLineOfSight;

    [Tooltip("Enemy starts shooting when player crosses this line")]
    public float shootingRange;

    [Header("Time between shots ")]
    public float fireRate;
    private float nextFireTime; // is used as timer to control fire rate

    [Header("Projectile Prefab")]
    public GameObject enemyProjectile;
    [Header("Projectile Origin - manually add")]
    public GameObject enemyProjectileParent;
    [Header("Player Target")]
    public Transform playerPosition;

    void Start()
    {
        //assign values from enemy scriptable object
        canShoot = gameObject.GetComponent<EnemyClass>().enemyCharacter.canShoot;

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        fireRate = gameObject.GetComponent<EnemyClass>().enemyCharacter.fireRate;
        moveSpeed = gameObject.GetComponent<EnemyClass>().enemyCharacter.patrolSpeed;

        lineOfsight = gameObject.GetComponent<EnemyClass>().enemyCharacter.lineOfSight;
        aggroLineOfSight = gameObject.GetComponent<EnemyClass>().enemyCharacter.aggroLineOfSight;
        shootingRange = gameObject.GetComponent<EnemyClass>().enemyCharacter.shootingRange;
        enemyProjectile = gameObject.GetComponent<EnemyClass>().enemyCharacter.projectile;

    }

    private void FixedUpdate()
    {
        float distanceFromPlayer = Vector2.Distance(playerPosition.position, transform.position);
        float temp = lineOfsight;

        if (playerPosition != null)
        {
            if (canShoot == false)
            {
                if (distanceFromPlayer < lineOfsight)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
                    
                }
            }

            else if (canShoot == true)
            {
                if (distanceFromPlayer < lineOfsight && distanceFromPlayer > shootingRange)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
                    lineOfsight = aggroLineOfSight;
                }
                else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
                {
                    Instantiate(enemyProjectile, enemyProjectileParent.transform.position, Quaternion.identity);
                    nextFireTime = Time.time + fireRate;
                    
                }
                else
                {
                    lineOfsight = temp;
                }
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfsight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

}
