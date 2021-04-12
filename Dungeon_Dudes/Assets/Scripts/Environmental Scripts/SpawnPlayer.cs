using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    /*Attach this to an empty game object to make it spawn assigned player.
      * FG 4/11
      */

    public int whenToSpawn;
    LevelGeneration levelGenerator;
    public GameObject[] objects;
    public bool isPlayerSpawner;

    public int players;
    

    void Start()
    {
        levelGenerator = FindObjectOfType<LevelGeneration>();

        if(levelGenerator.maxPlayers ==1 )
        {
            spawnPlayer();
        }
    }


    void spawnPlayer()
    {
            Vector3 position;
            position = new Vector3(transform.position.x, transform.position.y, -3);
            Instantiate(objects[0], position, Quaternion.identity);
            isPlayerSpawner = false;
            levelGenerator.maxPlayers--;
    }
}
