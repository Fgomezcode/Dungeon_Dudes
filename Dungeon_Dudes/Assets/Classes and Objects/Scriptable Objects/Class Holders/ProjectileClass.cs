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

    SpriteRenderer playerProjectileSprite;
   
    void Start()
    {   
        //access the sprite renderer attached to the projectile
        playerProjectileSprite = GetComponent<SpriteRenderer>();

        //assing the sprite to the projectile
        playerProjectileSprite.sprite = projectileStats.playerProjectileSprite;   
    }

 
    void Update()
    {
        destroyProjectile(projectileStats.playerProjectileLife);
    }


    //this function destroys the object prefab
    void destroyProjectile(float timeToDestroy)
    {
        if (Time.time >=projectileStats.playerProjectileLife)
        {
            Destroy(gameObject,timeToDestroy);
        }
    }
}
