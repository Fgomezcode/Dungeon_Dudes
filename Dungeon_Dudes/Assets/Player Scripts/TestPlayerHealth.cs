using UnityEngine;


//this was for testing no longer needed. 
//FG - 3/25 @2am

public class TestPlayerHealth : MonoBehaviour
{

    // testing player collision
    public float health = 10;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=1)
        {
            Destroy(gameObject);
        }
    }

    public void Bump(float damage)
    {
        health -= damage;
    }
}
