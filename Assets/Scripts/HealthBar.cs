using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Chris Pimentel
 * 11/5/25
 * Controls display on UI of health and health tanks
 */

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public HealthTanksUI healthTanks;

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health % 100;

        healthTanks.UpdateTanks(health / 100);
    }

 
}
