using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // this is the healthBar script i created to keep track of the Health bar status and allow the health bar coloue to reduce as the damage reduces the health to the lowest.
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void setMaxHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(health * 100);
    }
    public void setHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(health);
    }

}
