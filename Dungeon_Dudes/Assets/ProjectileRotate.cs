using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRotate : MonoBehaviour
{
    [Header("Rotation Speed")]
    [Range(50,1000)]
    public int rotationSpeed;

    public bool canRotate;
    void Update()
    {
        rotateProjectile();
    }

    void rotateProjectile()
    {
        if(canRotate)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canRotate = false;
        transform.Rotate(Vector3.forward * 0 * Time.deltaTime);
    }
}
