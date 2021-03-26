using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public EnemyObject enemyCharacter;

    private void Awake()
    {
        applyClass(enemyCharacter);
    }

    private void applyClass(EnemyObject enemyCharacter)
    {
        //find the movement script and assign the character class moveSpeed value
        //to the movement script moveSpeed value.
        gameObject.GetComponent<Movement>().moveSpeed = enemyCharacter.patrolSpeed;

        // find the sprite renderer attached to this object and assign the chracter sprite 
        // to the sprite renderer --- overwrites any sprite that is being used for work purposes
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyCharacter.enemySprite;
    }



}
