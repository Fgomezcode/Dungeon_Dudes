using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClass : MonoBehaviour
{
    /*this script assigns the sprite from the scriptable object to the prefab
     * it also asigns the speed to the prefab and will destroy the object when it has been on screen 
     * for too long, or hasnt collided with anything.
     * FG 3/28
     */
    public PlayerProjectile projectileStats;
    [HideInInspector]
    public float projectileDamage;
    [HideInInspector]
    public float projectileMaxDamage;
    SpriteRenderer playerProjectileSprite;
   
    void Start()
    {
        cacheRefs();
    }

    void Update()
    {
        destroyProjectile(projectileStats.playerProjectileLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wallbreak wall = collision.collider.GetComponent<Wallbreak>();
        if (wall)
        {
            // gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            particleDisplay();
            Destroy(gameObject, .25f);
        }

        EnemyClass enemy = collision.collider.GetComponent<EnemyClass>();
        if (enemy)
        {
            // gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            particleDisplay();
            Destroy(gameObject, .25f);
        }
    }

    //this function destroys the object prefab
    void destroyProjectile(float timeToDestroy)
    {    
        if (Time.time >= timeToDestroy)
        {
            Destroy(gameObject,timeToDestroy);
        }
    }

    // collision checks for wall and enemy collision-- could be separate script but not at this scale fg 4/14

    void cacheRefs()
    {
        projectileStats = GetComponent<ProjectileClass>().projectileStats;

        projectileDamage = projectileStats.playerProjectileBaseDamage;
        projectileMaxDamage = projectileStats.playerProjectileMaxDamage;
        //access the sprite renderer attached to the projectile
        playerProjectileSprite = GetComponent<SpriteRenderer>();
        //assing the sprite to the projectile
        playerProjectileSprite.sprite = projectileStats.playerProjectileSprite;
    }

    void particleDisplay()
    {
        PlayParticle particle = GetComponentInChildren<PlayParticle>();
        particle.particlePlay();
    }
}
