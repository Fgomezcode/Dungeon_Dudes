using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /*This script is kind of confusing and I will add the notes later,
     * FG 3/28
     */
    
    /*this script caches the shooting stats, and instantiates a playerprojectile
     * with vector towards the mouseposition at the moment of instancing.
     * this script need playeraiming script in order for it to work
     * FG 3/30
     */

    PlayerProjectile projectileStats; //projectile scriptable object
    PlayerObject character; //player scriptable object
    GameObject projectilePrefab;
    PlayerAiming firePoint;
    float projectileSpeed;

    private void Awake()
    {
        // find and access the components needed and assign appropriate values
        //access the projectile stats throught the character class,
        projectileStats = gameObject.GetComponent<CharacterClass>().character.playerProjectile.GetComponent<ProjectileClass>().projectileStats;

        //access the player character class
        character = GetComponent<CharacterClass>().character;

        // assign the projectile prefab
        projectilePrefab = character.playerProjectile;

        // assign the projectile speed
        projectileSpeed = projectilePrefab.GetComponent<ProjectileClass>().projectileStats.playerProjectileSpeed;
       
        // find and assign the firepoint by searching through the players child objects
        firePoint = GetComponentInChildren<PlayerAiming>();
        
        //make timer and reload the same so player can shoot on spawn
        projectileStats.playerProjectileTimer = projectileStats.playerProjectileReload;
    }

    void Update()
    {
        checkFire();
    }

    /*this function will spawn a bullet object and apply vector towards mouse position on screen
     */
    void Shoot()
    {
        if (projectileStats.playerProjectileTimer >= projectileStats.playerProjectileReload)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(firePoint.transform.up * projectileSpeed, ForceMode2D.Impulse);
           // character.playerProjectileTimer = 0; // set timer to zero and you cant shoot anymore
        }

        if (projectileStats.playerProjectileTimer >= projectileStats.playerProjectileReload)
        {
            projectileStats.playerProjectileTimer = 0;
        }
    }

    //****************************************
    public void reloadTimer()
    {
        if (projectileStats.playerProjectileTimer < projectileStats.playerProjectileReload)
        {
            projectileStats.playerProjectileTimer += Time.deltaTime;
        }
    }

    void checkFire()
    {
        //check for player input
        if (Input.GetButtonDown("Fire1"))
        {
            // call the shoot function
            Shoot();
        }
        //start the reload timer
        reloadTimer();
    }
}