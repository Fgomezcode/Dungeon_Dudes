using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    /*this script is used to get value from chracter class, and store its health values
     * so that i may be accessed without changing the values of scriptable object
     * FG 3/25
     */
    PlayParticle healParticles;
    public HealthSlider healthBar;
    private CharacterClass characterClass;
    public float maxHealth;// assign the maxhealth value to the object this is attached to
    public float health;

    void Start()
    {
        /*get the CharacterClass component, access the maxHealth value
         * assign it to local variable also called maxHealth
         * assign that value to local var health, so that the scriptable object
         * maxhealth value does not change.
         */
        characterClass = gameObject.GetComponent<CharacterClass>();

        maxHealth =characterClass.character.maxHealth;
        health = maxHealth;

        // find and access the healthslider UI;
        healthBar = FindObjectOfType<HealthSlider>();
        healthBar.setMaxHealth(characterClass.character.maxHealth);

        healParticles = GetComponentInChildren<PlayParticle>();

    }

   //This is the life decay over time, health is decrease by one persecond.
    private void FixedUpdate()
    {
        health = playerLife();
    }

    float playerLife()
    {
        health -= Time.deltaTime;
        healthBar.setHealth(health);

        if(health <=0 )
        {
            Destroy(gameObject);
        }    
        return health;
    }

    //This function will subtract 'damage' from player health every time it is called
    public void damagePlayer(float damage)
    {
        //subtract damage from health.
        health -= damage;
        // update the healthbar witht the new health valuel
        healthBar.setHealth(health);

        //this will destroy the player object when health reaches zero
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    //called by item pick up to heal the player when colliding. 
    public void healPlayer(float healAmount)
    {
        health += healAmount;
        healParticles.particlePlay();
        healthBar.setHealth(health);
        
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void healPlayerOnKill(float healAmount)
    {
        health += healAmount;
        //healParticles.particlePlay();
        healthBar.setHealth(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
