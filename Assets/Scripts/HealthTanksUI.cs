using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/5/25
 * Controls display of health tanks on UI
 */

public class HealthTanksUI : MonoBehaviour
{
    public GameObject[] healthTanks;

    private void Start()
    {
        ResetTanks(); //Sets tanks to 0
    }


    /// <summary>
    /// Takes an int that represents total health in the hundreds (1 = 100, 2 = 200)
    /// Activates and deactivates health tanks on UI based off of how many 100's of health the player has
    /// </summary>
    /// <param name="health"></param>
    public void UpdateTanks(int health)
    {
        //Keeps Health from overreaching the array and breaking something
        if (health > healthTanks.Length)
        {
            health = healthTanks.Length;
        }

        ResetTanks(); //Sets tanks to 0

        //Activates health tanks based off of current health
        for (int i = 0; i < health; i++)
        {
            healthTanks[i].gameObject.SetActive(true);
        }
    }


    /// <summary>
    /// Resets tanks to 0 to be set again
    /// </summary>
    void ResetTanks()
    {
        for (int i = 0; i < healthTanks.Length; i++)
        {
            healthTanks[i].gameObject.SetActive(false);
        }
    }
}
