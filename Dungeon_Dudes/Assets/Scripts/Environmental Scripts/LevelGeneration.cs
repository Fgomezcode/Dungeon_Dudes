using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [Header("LR = 0, LRB =1, LRT = 2, LRTB = 3")]
    public Transform[] startingPositions;
    public GameObject[] rooms; // 0 = LR 1 = LRB   2 = LRT   3 = all4

    int direction;
    public float moveAmount;

    public float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    public float minX;
    public float maxX;
    public float minY;
    private int downCounter;
    public bool stopGeneration;

    public LayerMask Room;
    private void Start()
    {
        int randomStartingPosition = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randomStartingPosition].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        roomTimer();
    }

    private void move()
    {

        if (direction == 1 || direction == 2) // move right
        {
            moveRight();

        }
        else if (direction == 3 || direction == 4)//move left
        {
            moveLeft();

        }
        else if (direction == 5) //move down
        {
            moveDown();
        }

    }

    private void moveRight()
    {
        if (transform.position.x < maxX)
        {
            downCounter = 0;
            Vector2 newPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPosition;

            int randomNum = Random.Range(0, rooms.Length);
            Instantiate(rooms[randomNum], transform.position, Quaternion.identity);

            direction = Random.Range(1, 6);// aftermoving right the direction is to keep going right until it goes down

            if (direction == 3)
            {
                direction = 2;
            }
            else if (direction == 4)
            {
                direction = 5;
            }
        }
        else
        {
            direction = 5;
        }
    }

    private void moveLeft()
    {
        if (transform.position.x > minX)
        {
            downCounter = 0;
            Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
            transform.position = newPosition;

            int randomNum = Random.Range(0, rooms.Length);
            Instantiate(rooms[randomNum], transform.position, Quaternion.identity);

            direction = Random.Range(3, 6);// aftermoving right the direction is to keep going left until it goes down
        }
        else
        {
            direction = 5;
        }
    }

    private void moveDown()
    {
        downCounter++;

        if (transform.position.y > minY)
        {
            Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, Room);
            if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
            {
                if (downCounter >= 2)
                {
                    roomDetection.GetComponent<RoomType>().roomDestruction();
                    Instantiate(rooms[3], transform.position, Quaternion.identity);
                }
                else
                {
                    roomDetection.GetComponent<RoomType>().roomDestruction();

                    int randomBottomRoom = Random.Range(1, 4);
                    if (randomBottomRoom == 2)
                    {
                        randomBottomRoom = 1;
                    }
                    Instantiate(rooms[randomBottomRoom], transform.position, Quaternion.identity);
                }
            }

            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
            transform.position = newPosition;

            int randomNum = Random.Range(2, 4);
            Instantiate(rooms[randomNum], transform.position, Quaternion.identity);

            direction = Random.Range(1, 6);
        }
        else
        {
            //stop place exit.
            stopGeneration = true;
        }
    }

    private void roomTimer()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false)
        {
            move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            if (stopGeneration == false)
                timeBtwRoom -= Time.deltaTime;
        }
    }
}
