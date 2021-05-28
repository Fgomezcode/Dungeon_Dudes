using UnityEngine;

public class TeleportationTriggers : MonoBehaviour
{
    TeleportFunction enemyTeleport;
    private void Start()
    {
        enemyTeleport = GetComponent<TeleportFunction>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectileClass playerProjectile = collision.GetComponent<ProjectileClass>();
        if (playerProjectile)
        {
            enemyTeleport.teleport();
            GetComponentInChildren<PlayParticle>().particlePlay();
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
