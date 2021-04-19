using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    /*This script applies damage to the enemy when they collide with the player
     * FG 3/30
     */

    //public PlayParticle enemyParticles;
    PlayerHealth playerHealth;
    EnemyClass enemyStats;
    GameManager gameManager;
    public bool takesProjectileDamage;
    private float enemyHealth;

    PlayParticle enemyParticle;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemyStats = GetComponent<EnemyClass>();
        enemyHealth = enemyStats.enemyCharacter.maxHealth;
        enemyParticle = gameObject.GetComponentInChildren<PlayParticle>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterClass player = collision.collider.GetComponent<CharacterClass>();
        if(player )
        {
            takeDamage(player.character.collisionDamage);
        }

        ProjectileClass playerProjectile = collision.collider.GetComponent<ProjectileClass>();
        if (playerProjectile && takesProjectileDamage)
        {
            takeDamage(playerProjectile.projectileDamage) ;
            
        }    
    }



    public void takeDamage(float damage)
    {
        enemyHealth -= damage;
        
        if (enemyHealth <= 0)
        {
            // there is a kill component it will kill - destroy parent obj
            Destroyer kill = GetComponentInParent<Destroyer>();
            if(kill)
            {
                kill.kill();
            }
            lootCheck();//buuild loot system into own script
            enemyDeath();
        }
    }

    void lootCheck()
    {
        if (enemyStats.enemyCharacter.isSpawnMore)
        {
            spawnMore();
        }
        else
        {
            return;
        }
        if (enemyStats.enemyCharacter.isHealthDrop)
        {
            spawnHealthDrop();
        }
        if (enemyStats.enemyCharacter.isManaDrop)
        {
            spawnManaDrop();
        }
        if (enemyStats.enemyCharacter.isKeyDrop)
        {
            spawnKeyDrop();
        }
    }

    float  rollDropRate(float min, float max)
    {
        float roll;

        roll = Random.Range(min, max);

        return roll;
    }

    void spawnMore()
    {
        float roll;
        for(int i =0; i < enemyStats.enemyCharacter.howMany; i++)
        {
            roll = rollDropRate(0, 90);
            if (roll > 20)
            {
                Debug.LogError("your rolled a: " + roll);
                int randomEnemy = Random.Range(0, enemyStats.enemyCharacter.enemiesOnDeath.Length);
                //spawns new enemy closer, further or same spot
                int randX = Random.Range(-1, 2);
                int randY = Random.Range(-1, 2);
                Instantiate(enemyStats.enemyCharacter.enemiesOnDeath[randomEnemy], new Vector3(transform.position.x + randX, transform.position.y + randY, 0f), Quaternion.identity);
                Debug.Log("Enemy Spawned");
            }
        }
  
    }

    void spawnHealthDrop()
    {
        int randomHealthDrop = Random.Range(0, enemyStats.enemyCharacter.healthPool.Length);
        float randX = Random.Range(-1, 1);
        float randY = Random.Range(-1, 1);
        if(rollDropRate(0,100) > 80f)
        {
            //loot drops exactly where the enemy died
            // Instantiate(enemyStats.enemyCharacter.healthPool[randomHealthDrop],transform.position, Quaternion.identity);
            Instantiate(enemyStats.enemyCharacter.healthPool[randomHealthDrop], new Vector3(transform.position.x + randX, transform.position.y + randY, 0f), Quaternion.identity);
            Debug.LogError("Health drop");
        }
        
    }

    void spawnManaDrop()
    {
        int randomManaDrop = Random.Range(0, enemyStats.enemyCharacter.manaPool.Length);
        float randX = Random.Range(-1, 1);
        float randY = Random.Range(-1, 1);
        //loot drops exactly where the enemy died
        //Instantiate(enemyStats.enemyCharacter.healthPool[randomManaDrop], transform.position, Quaternion.identity);
        Instantiate(enemyStats.enemyCharacter.manaPool[randomManaDrop], new Vector3(transform.position.x + randX, transform.position.y + randY, 0f), Quaternion.identity);
        Debug.LogError("mana drop");

    }

    void spawnKeyDrop()
    {
        //this can also be used to drop rare items? 

        int randomKeyDrop = Random.Range(0, enemyStats.enemyCharacter.keyPool.Length);
        float randX = Random.Range(-1, 1);
        float randY = Random.Range(-1, 1);
        //loot drops exactly where the enemy died
        //Instantiate(enemyStats.enemyCharacter.healthPool[randomKeyDrop], transform.position, Quaternion.identity);
        Instantiate(enemyStats.enemyCharacter.keyPool[randomKeyDrop], new Vector3(transform.position.x + randX, transform.position.y + randY, 0f), Quaternion.identity);
        Debug.LogError("key drop");

    }

    void enemyDeath()
    {
        if (gameObject.GetComponent<Collider2D>().enabled == true)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        if (enemyParticle)
        {
            enemyParticle.particlePlay();
        }
        else
        {
            return;
        }
        gameManager.playerScore += enemyStats.enemyCharacter.pointValue;
        playerHealth.healPlayer(enemyStats.enemyCharacter.pointValue);
        Destroy(gameObject, GetComponentInChildren<ParticleSystem>().main.duration);
    }
}
