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


    // refactor this into shooting enemy script, chasing enemy script and make an enemy class/prefab for every enemy type
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
    GameObject player;
    
    void Start()
    {
        loadAssets();
    }
 
    //this will only work if there is a player on the screen.
    private void FixedUpdate()
    {
        findTransform();
        //pass the ref. because null will be caught a little after the game loads, with out having to Invoke
        findTarget(player);
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
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void findTransform()
    {
        //if there is a player loaded in game
        if (playerPosition == true)
        {
            float distanceFromPlayer = Vector2.Distance(playerPosition.position, transform.position);
            float temp = lineOfsight;

            playerPosition = player.transform;

            if (canShoot == false)
            {
                if (playerPosition != null)
                {
                    if (distanceFromPlayer < lineOfsight)
                    {
                        //if there is a player and this enemy cannot shoot, then it will move to the player
                        transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
                    }
                }
            }
            
            else
            {
                float randX = Random.Range(-1f, 1f);
                float randY = Random.Range(-1f, 1f);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x * randX, gameObject.transform.position.y * randY, 0f);
            }


            if (canShoot == true)
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

    void findTarget( GameObject player)
    {
        if (player)
        {
            playerPosition = player.transform;
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
