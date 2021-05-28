using UnityEngine;

public class TeleportingEnemy : MonoBehaviour
{
    EnemyPatrol patrol;
    TeleportFunction enemyTeleport;

    void Start()
    {
        patrol = GetComponent<EnemyPatrol>();
        enemyTeleport = GetComponent<TeleportFunction>();
        patrol.patrolStart();
        enemyTeleport.initList();
    }
    private void Update()
    {
        patrol.activePatrol();
    }

}
