using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolMinX;
    public float patrolMaxX;
    public float patrolMinY;
    public float patrolMaxY;

    public Transform patrolTarget;
    EnemyClass enemyStats;
    private float waitTime;
    public float startWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        enemyStats = GetComponent<EnemyClass>();
    }


    public void patrolStart()
    {
        waitTime = startWaitTime;
        patrolTarget.position = new Vector2(Random.Range(patrolMinX, patrolMaxX), Random.Range(patrolMinY, patrolMaxY));
    }


    public void activePatrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolTarget.position, enemyStats.enemyCharacter.patrolSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, patrolTarget.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                patrolTarget.position = new Vector2(Random.Range(patrolMinX, patrolMaxX), Random.Range(patrolMinY, patrolMaxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void chasePlayer(Transform playerPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemyStats.enemyCharacter.patrolSpeed * Time.deltaTime);

    }
}
