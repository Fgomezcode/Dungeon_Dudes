using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFunction : MonoBehaviour
{
    public List<Vector2> teleportSpots;
    public int startingX;
    public int endingX;
    public int startingY;
    public int endingY;
    private int randomSpot = 0;
 
    public void initList()
    {
        teleportSpots.Clear();
        addSpots();
    }

    public void addSpots()
    {
        for (int x = startingX; x < endingX; x++)
        {
            for (int y = startingY; y < endingY; y++)
            {
                teleportSpots.Add(new Vector2(x, y));
            }
        }
    }

    public void teleport()
    {
        int temp = randomSpot;
        randomSpot = Random.Range(0, teleportSpots.Count);
        if (randomSpot != temp)
        {
            Vector2 newlocation = new Vector2(teleportSpots[randomSpot].x, teleportSpots[randomSpot].y);
            gameObject.transform.localPosition = newlocation;
        }
        else
        {
            randomSpot = Random.Range(0, teleportSpots.Count);
        }
    }
}
