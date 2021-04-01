using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    private string currentState;
    private PlayerObject character;

    //This is not attached to the player yet
    //May not be neccessary, FG 3/30

    //***** ANIMATION NAMES ARE CASE SENSITIVE, MUST BE THE EXACT SAME AS THE ANIMATION FILE********//

    //RANGER ANIMATIONS
    const string RANGER_IDLE = "RangerIdle";

    //WIZARD ANIMATIONS
    const string WIZARD_IDLE = "WizardIdle";

    //WARRIOR ANIMATIONS
    const string WARRIOR_IDLE = "WarriorIdle";

    //VALKYRIE ANIMATIONS
    const string VALKYRIE_IDLE = "ValkyrieIdle";


    void Start()
    {
        //CACHE COMPONENTS
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterClass>().character;
       
    }

    //THIS FUNCTION CHANGES THE ANIMATIONS TO MATCH THE STATE
    // Unity changes animations with string values
    void changeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }

        animator.Play(newState);

        currentState = newState;
    }
}
