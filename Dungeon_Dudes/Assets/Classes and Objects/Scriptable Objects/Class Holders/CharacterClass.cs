using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    /*The only purpose of this script is to hold the 
     * character class so it can be referenced 
     * in game, globally.
     * and apply the values from the class to 
     * the components attached to object
     * FG 3/25
     */

    [Header("Warrior, Wizard, Ranger, Valkyrie")]
    public PlayerObject character;
    
    private void Awake()
    {
        applyClass(character);
    }

    private void applyClass(PlayerObject character)
    {
        //find the movement script and assign the character class moveSpeed value
        //to the movement script moveSpeed value.
        GetComponent<Movement>().moveSpeed = character.MoveSpeed;

        // find the sprite renderer attached to this object and assign the chracter sprite 
        // to the sprite renderer --- overwrites any sprite that is being used for work purposes
        GetComponent<SpriteRenderer>().sprite = character.playerSprite;

    }
}
