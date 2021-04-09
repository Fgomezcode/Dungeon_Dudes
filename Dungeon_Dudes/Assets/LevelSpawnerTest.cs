using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class LevelSpawnerTest : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int cols;
    public int rows;

    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);

    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemySpawner;
    public GameObject[] outerWallTiles;

    private Transform levelHolder;

    private List<Vector3> gridPositions = new List<Vector3>();


    //create a list of sequentialy placed vector points
    public void initialalizeList()
    {
        gridPositions.Clear(); // clear the list, or make sure its clear.

        //nested for loops outer for x pos cols, inner for y pos rows. 
        for(int x =1; x <cols-1; x++)
        {
            for (int y = 1; y < rows; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f)); // add vector position (x,y,0f) first (1,1,0) then (2,2,0) and so on.
            }
        }
    }


    //level or room setup -- creat new level, this function will add the outer walls and the inner floor.
    private void levelSetup()
    {
        //create level holder object that will be the parent
        levelHolder = new GameObject("Level").transform;

        //negative one so that it makes the outer walls before the premade list cols
        // and pos one so that it goes past the premade row
        for(int x = -1; x< cols +1; x++)
        {
            for(int y =-1; y< rows +1; y++)
            {
                //tell it what to instantiate
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                //if outside of list spawn wall tile
                if(x ==-1 || x == cols || y == -1|| y ==rows)
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
                // declare gameObj and assign the object to instantiate 
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                //instance the object.
                instance.transform.SetParent(levelHolder);
            }
        }

    }

    //this function will find a random location inside the grid that is made in initializeList
    Vector3 randomPos()
    {
        // assing random number in range of gridpos that will be used as the index in the array
        int randomIndex = Random.Range(0, gridPositions.Count);
        //declare local var of vector 3 to assign the position, using the randomindex
        Vector3 randomPosition = gridPositions[randomIndex];

        // remove the position from the list so it is not used twice
        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }



    //this function will lay out objects atr the random positions returned by randomPos
    void layoutObjects(GameObject[] tileArray, int minimum, int maximum)
    {
        // pick random value that will set how many items spawn.
        int objectCount = Random.Range(minimum, maximum + 1);

        for(int i = 0; i < objectCount; i++)
        {
            //get random position and assign it to local var
            Vector3 randomPosition = randomPos();

            // get object from loot array/enemy array
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            // instantiate the random tile, in random position with no rotation.
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void setupScene(int level)
    {
        //call levelSetup
        levelSetup();
        //call initList -- make the list of positions
        initialalizeList();

        // layout the objects from desired array.
        layoutObjects(wallTiles, wallCount.minimum, wallCount.maximum);
        layoutObjects(foodTiles, foodCount.minimum, wallCount.maximum);

        int enemyCount = (int)Mathf.Log(level, 2f);

        layoutObjects(enemySpawner, enemyCount, enemyCount);
        Instantiate(exit, new Vector3(cols - 1, rows - 1, 0f), Quaternion.identity);
    }


}

