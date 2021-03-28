using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readSpawnPoint : MonoBehaviour
{
    public GameObject[] walls;
    public bool isTopLeft;
    public bool isTopMid;
    public bool isTopRight;
    LevelSpawnerTest spawnInfo;

    void Start()
    {
        spawnInfo = GetComponentInParent<LevelSpawnerTest>();    


        if(spawnInfo.topLeft == true && isTopLeft == true)
        {
            Instantiate(walls[0], gameObject.transform.position, Quaternion.identity);
        }
        if (spawnInfo.topMid == true && isTopMid == true)
        {
            Instantiate(walls[1], gameObject.transform.position, Quaternion.identity);
        }
        if (spawnInfo.topRight == true && isTopRight == true)
        {
            Instantiate(walls[2], gameObject.transform.position, Quaternion.identity);
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
