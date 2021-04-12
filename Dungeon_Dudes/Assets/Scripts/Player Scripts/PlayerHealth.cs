using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    /*this script is used to get value from chracter class, and store its health values
     * so that i may be accessed without changing the values of scriptable object
     * FG 3/25
     */

    public HealthSlider healthBar;
    private CharacterClass characterClass;
    public float maxHealth;
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

        healthBar = FindObjectOfType<HealthSlider>();
        healthBar.setMaxHealth(characterClass.character.maxHealth);

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


}
