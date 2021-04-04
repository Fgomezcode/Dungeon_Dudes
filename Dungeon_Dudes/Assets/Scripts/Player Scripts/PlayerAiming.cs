using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    /*This script controls the rotation of the fire point object attached to the player
     * and must be attached to the playerBulletSpawn oject, which is a child of the player
     * The mouse is located in world scene, and a vector is created and assigned to the bulletSpawner
     */

    Transform playerPosition;
    Rigidbody2D playerProjectileSpawner;
    Camera mainCamera;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Awake()
    {
        //cache refs.

        //find the rigid body attached to the player
        playerProjectileSpawner = GetComponent<Rigidbody2D>();

        //scene camera, used to find and track the mouse position.
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        // call findMousePos every frame, so aiming is accurate
        findMousePos();

        assignVector();

    }


    //this function finds the mouse position in the game world, and caches it so the fixed update can create a vector in that direction.
    private void findMousePos()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
         
    }

    //assigns the vector to player projectile spawner.
    private void assignVector()
    {
        Vector2 lookDirection = mousePosition - playerProjectileSpawner.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        playerProjectileSpawner.rotation = angle;
    }
}