using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    /*This is used to assign the values to various scripts
     * and also used to access the ENEMYOBJECT
     * more notes later
     * FG 3/26
     */

    [Header("Mob, Mid, Boss, Fire, Ice, etc.")]
    public EnemyObject enemyCharacter;

    private void Awake()
    {
        applyClass(enemyCharacter);
    }

    private void applyClass(EnemyObject enemyCharacter)
    {
        //find the movement script and assign the character class moveSpeed value
        //to the movement script moveSpeed value.
        //gameObject.GetComponent<EnemyMovement>().moveSpeed = enemyCharacter.patrolSpeed;

        // find the sprite renderer attached to this object and assign the chracter sprite 
        // to the sprite renderer --- overwrites any sprite that is being used for work purposes
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyCharacter.enemySprite;
    }



}
