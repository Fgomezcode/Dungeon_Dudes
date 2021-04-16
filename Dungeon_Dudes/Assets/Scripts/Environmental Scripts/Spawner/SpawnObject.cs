using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    /*Attach this to an empty game object to spawn anything.
     * FG 4/11
     */

    LevelGeneration levelGenerator;
    public GameObject[] objects;


    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject instance = Instantiate(objects[rand], transform.position, Quaternion.identity);   
        Destroy(gameObject,2f);
    }
}
