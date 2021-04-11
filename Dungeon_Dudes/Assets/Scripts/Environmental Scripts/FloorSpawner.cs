using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public int rows;
    public int cols;

    public GameObject[] floorTile;

    private Transform floor;

    private void Start()
    {
        spawnFloors();
    }

    private void spawnFloors()
    {
        //set cols and row to random int value so that every new room is different size;

        GameObject mainFloor = new GameObject("Floor");
        floor = mainFloor.transform;

        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject instance = Instantiate(floorTile[Random.Range(0, floorTile.Length)], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(floor);
            }
        }
        floor.position = this.transform.position;
    }
}
