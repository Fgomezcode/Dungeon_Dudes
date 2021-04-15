using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*This script controls enemy spawn points
     * it stores the enemy PREFABS in an array
     * and allows each one to spawn a specific 
     * enemy, or spawn a random enemy 
     * 
     * The spawn range is set by adjusting the min max 
     * parameters, spawn time controls time between enemies
     * spawning.
     * FG 3/27
     */

    [Header("Enemy Elements")]
    [Tooltip("Store from weak to strong")]
    public GameObject[] enemyToSpawn;

    [Header("Enemy That Will Spawn")]
    public int enemyChoice;
    public bool isRandom;
  
    [Header("Spawn Range Settings")]
    [Range(-5,0)]
    public float spawnXmin;
    [Range(0,5)]
    public float spawnXmax;
    [Range(-5,0)]
    public float spawnYmin;
    [Range(0,5)]
    public float spawnYmax;

    float spawnPosX;
    float spawnPosY;

    [Header("Time Before Next Spawn")]
    public float spawnRate;
    float nextSpawn = 0;
    public int maxEnemies;
    public float spawnerHealth;

void Start()
    {
        //This spawns a random enemy it will be assigned a random value based on 
        //the amount of enemies stored. 
    }

    private void Update()
    {
        if (maxEnemies > 0)
        {
            Invoke("spawnEnemy", spawnRate);
        }
    }

    void spawnEnemy()
    {
        if (isRandom == true)
        {
            enemyChoice = Random.Range(0, enemyToSpawn.Length);
        }
        if (Time.time>nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnPosX = Random.Range(spawnXmin, spawnXmax);
            spawnPosY = Random.Range(spawnYmin, spawnYmax);
            Vector2 whereToSpawn = new Vector2( gameObject.transform.position.x + spawnPosX,gameObject.transform.position.y + spawnPosY);
            Instantiate(enemyToSpawn[enemyChoice], whereToSpawn, Quaternion.identity);
            --maxEnemies;
        }
    }
}