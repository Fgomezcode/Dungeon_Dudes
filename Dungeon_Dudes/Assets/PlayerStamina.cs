using UnityEngine;
using UnityEngine.UI;
public class PlayerStamina : MonoBehaviour
{
    public Rigidbody2D playerBody;
    Movement playerMovement;
    CharacterClass characterClass;

    public float playerStamina;
    public StaminaSlider staminaDisplay;
    public Image sliderFill;
    public Image sliderBorder;
    // Start is called before the first frame update
    void Start()
    {
        cacheRefs();
    }

    // Update is called once per frame
    void Update()
    {
       // hideStaminaBar();
    }

    void cacheRefs()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<Movement>();
        characterClass = GetComponent<CharacterClass>();
        staminaDisplay = FindObjectOfType<StaminaSlider>();
        playerStamina = characterClass.character.maxStamina;
        sliderFill = GameObject.FindGameObjectWithTag("StaminaFill").GetComponent<Image>();
        sliderBorder = GameObject.FindGameObjectWithTag("StaminaBorder").GetComponent<Image>();
        
        //set the stamina bar to display the maximum player stamina
        staminaDisplay.setMaxStamina(playerStamina);
    }



   public void regenStamina()
    {
        if (playerStamina < characterClass.character.maxStamina)
        {
            playerStamina += Time.fixedDeltaTime * (5 + characterClass.character.staminaRegenRate); // add stamina regen property to character
            staminaDisplay.setStamina(playerStamina);
        }
    }

    public void staminaCost(float cost)
    {
        playerStamina -= cost;
        staminaDisplay.setStamina(playerStamina);
    }


    public void hideStaminaBar()
    {
        if (staminaDisplay.GetComponentInParent<Slider>().value == staminaDisplay.GetComponentInParent<Slider>().maxValue)
        {
            sliderFill.enabled = false;
            sliderBorder.enabled = false;
        }
        else if (staminaDisplay.GetComponentInParent<Slider>().value != staminaDisplay.GetComponentInParent<Slider>().maxValue)
        {
            sliderFill.enabled = true;
            sliderBorder.enabled = true;
        }
    }


   public void sprintCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerMovement.isMoving && playerStamina > 0)
        {
            playerBody.MovePosition(playerBody.position + playerMovement.movement * characterClass.character.MoveSpeed * Time.fixedDeltaTime);
            playerStamina -= (characterClass.character.staminaBurnRate / 2);
            staminaDisplay.setStamina(playerStamina);
        }
        else if (!playerMovement.isMoving && Input.GetKey(KeyCode.LeftShift))
        {
            regenStamina();
        }
        else
        {
            regenStamina();
        }
    }

}


