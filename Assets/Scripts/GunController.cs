using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * Chris Pimetnel
 * 11/4/25
 * Controls Gun and shoots bullets
 */

public class GunController : MonoBehaviour
{
    public PlayerController player; //Reference to player to check for gun upgrade

    public GameObject bullet; //Prefab of bullet
    public GameObject missile; //Prefab of missle

    // Update is called once per frame
    void Update()
    {
        //When the player presses the shoot button, fire bullets
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            FireGun();
    }


    /// <summary>
    /// Fires projectiles from player's gun
    /// </summary>
    private void FireGun()
    {
        if (player.HasMissiles())
        {
            FireMissile();
        }
        else
        {
            FireBullet();
        }
       

    }


    /// <summary>
    /// Fires bullets from gun
    /// </summary>
   private void FireBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    /// <summary>
    /// Fires missiles from gun
    /// </summary>
    private void FireMissile()
    {
        Instantiate(missile, transform.position, transform.rotation);
    }
    
}