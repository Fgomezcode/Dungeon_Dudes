using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    /*this script is used to get value from chracter class, and store its health values
     * so that i may be accessed without changing the values of scriptable object
     * FG 3/25
     */
    
    public float maxHealth;
    public float health;

    void Start()
    {
        /*get the CharacterClass component, access the maxHealth value
         * assign it to local variable also called maxHealth
         * assign that value to local var health, so that the scriptable object
         * maxhealth value does not change.
         */
        maxHealth = gameObject.GetComponent<CharacterClass>().character.maxHealth;
        health = maxHealth;
    }

}
