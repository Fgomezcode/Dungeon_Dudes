using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    /*This will spawn a random room in any open spaces after the main route is spawned
     * will only spawn open rooms
     * FG 4/11
     */
    public LayerMask whatIsRoom;
    public LevelGeneration levelGen;

    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 2, whatIsRoom);
        if (roomDetection == null && levelGen.stopGeneration == true)
        {
            //spawn random room
            int randomNum = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[randomNum], transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
    }
}
