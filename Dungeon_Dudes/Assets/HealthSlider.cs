using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{
    public Slider healthDisplay;
    public Gradient gradient;
    public Image fill;

    public void setMaxHealth(float health)
    {
        healthDisplay.maxValue = health;

        healthDisplay.value = health;

        fill.color =  gradient.Evaluate(1f);
        
    }

    public void setHealth(float health )
    {
        healthDisplay.value = health;
        fill.color = gradient.Evaluate(healthDisplay.normalizedValue);
    }
}
