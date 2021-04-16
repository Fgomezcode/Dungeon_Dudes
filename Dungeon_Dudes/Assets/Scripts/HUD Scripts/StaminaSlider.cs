using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaSlider : MonoBehaviour
{
    public Slider staminaDisplay;
    public Gradient gradient;
    public Image fill;


    public void setMaxStamina(float stamina)
    {
        staminaDisplay.maxValue = stamina;

        staminaDisplay.value = stamina;

        fill.color = gradient.Evaluate(1f);
    }

    public void setStamina(float stamina)
    {
        staminaDisplay.value = stamina;
        fill.color = gradient.Evaluate(staminaDisplay.normalizedValue);
    }
}
