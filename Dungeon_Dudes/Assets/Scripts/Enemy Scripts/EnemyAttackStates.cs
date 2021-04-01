using UnityEngine;

public class EnemyAttackStates : MonoBehaviour
{
    /* this needs to be refactored
     * to use ontrigger2d enter/exit
     * FG 3/26
     */


    /*This script sets 2 ranges. the first is when the enemy starts chasing the player, 
     * the second is when it stops and starts shooting.
     * if the enemy is set to not ranged it will chase the enemy, until out of range,
     * it will then start moving back towards the enemyspawner
     * FG 3/30
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
    public Transform enemySpawnerPosition;

    void Start()
    {
        loadAssets();
    }
 
    //this will only work if there is a player on the screen.
    private void FixedUpdate()
    {
        findTransform();
    }
    
    //FUNCTIONS
    private void loadAssets()
    {
        //assign values from enemy scriptable object
        canShoot = gameObject.GetComponent<EnemyClass>().enemyCharacter.canShoot;

        fireRate = gameObject.GetComponent<EnemyClass>().enemyCharacter.fireRate;
        moveSpeed = gameObject.GetComponent<EnemyClass>().enemyCharacter.patrolSpeed;

        lineOfsight = gameObject.GetComponent<EnemyClass>().enemyCharacter.lineOfSight;
        aggroLineOfSight = gameObject.GetComponent<EnemyClass>().enemyCharacter.aggroLineOfSight;
        shootingRange = gameObject.GetComponent<EnemyClass>().enemyCharacter.shootingRange;
        enemyProjectile = gameObject.GetComponent<EnemyClass>().enemyCharacter.projectile;


        enemySpawnerPosition = GameObject.FindGameObjectWithTag("EnemySpawner").transform;

        if (GameObject.FindGameObjectWithTag("Player"))
        {

            playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            gameObject.transform.position = enemySpawnerPosition.transform.position;
        }
    }


    private void findTransform()
    {
        if (playerPosition == true)
        {
            float distanceFromPlayer = Vector2.Distance(playerPosition.position, transform.position);
            float temp = lineOfsight;
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
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
            else
            {
                gameObject.transform.position = enemySpawnerPosition.transform.position;
            }
        }
    }


    //This draws the ranges on the game scene
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfsight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

}
