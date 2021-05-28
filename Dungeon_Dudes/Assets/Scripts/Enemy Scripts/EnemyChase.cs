using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    EnemyPatrol patrol;
    public EnemyClass enemyStats;
    public LayerMask playerLayer;
    public Transform player;

    public float startingPerimeter;
    public float chasePerimeter;
    public float aggroPerimeter;
    void Start()
    {
        patrol = GetComponent<EnemyPatrol>();
        enemyStats = GetComponent<EnemyClass>();
        chasePerimeter = startingPerimeter;
    }

    // Update is called once per frame
    void Update()
    {
        chasePlayer();
    }

    public void chasePlayer()
    {    
        Collider2D playerCheck = Physics2D.OverlapCircle(transform.position, chasePerimeter, playerLayer);

        if (playerCheck)
        {
            player = playerCheck.transform;
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemyStats.enemyCharacter.chaseSpeed * Time.deltaTime);
            chasePerimeter = aggroPerimeter;
        }
        if(!playerCheck)
        {   
            chasePerimeter = startingPerimeter;

            patrol.activePatrol();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, startingPerimeter);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chasePerimeter);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroPerimeter);
    }

}
