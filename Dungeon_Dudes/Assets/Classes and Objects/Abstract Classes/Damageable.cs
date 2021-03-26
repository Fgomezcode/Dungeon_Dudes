using UnityEngine;

/*
 * this class applies damage to items making them destructable
 * the item health is also assigned using max health
 * and applied to the object when instanced
 */

public  abstract class Damageable : MonoBehaviour
{

    //allows you to set the item health in the editor
    [Header("Set Individual Object Health")]
    [Tooltip("Health is set to maxhealth at runtime.")]

    // if the value is not set at runtime this is the default value.
    [SerializeField]
    private float maxHealth = 5;
    public float health = 5;

    //assigns max health upon instance
    private void Awake()
    {
        health = maxHealth;
    }

    // function that applies damage to object
    // deletes when heatlh < 0
    public void applyDamage(float damage)
    { 
        health -= damage;

        if(health <= 0)
        {
            //takes float parameter if a delay is needed
            Destroy(gameObject);
        }
    }
}
