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

    public float gunCooldownTime = 0.5f; //Determines cooldown time of gun
    private bool canFire; //Determines whether player can fire or not


    private void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player can fire
        if (canFire)
        {
            //When the player presses the shoot button, fire bullets
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
                FireGun();
        }
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
        
        //Sets a cooldown for the gun
        //Players can fire every half second
        StartCoroutine(WaitToFire());

    }


    /// <summary>
    /// Fires bullets from gun
    /// </summary>
   private void FireBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        canFire = false;
    }

    /// <summary>
    /// Fires missiles from gun
    /// </summary>
    private void FireMissile()
    {
        Instantiate(missile, transform.position, transform.rotation);
        canFire= false;
    }
    

    private IEnumerator WaitToFire()
    {
        //Player can no longer shoot gun
        canFire = false;

        //Gun cooldown
        yield return new WaitForSeconds(gunCooldownTime);
        //yield return new WaitForSecondsRealtime(gunCooldownTime);

        //Player can now fire gun
        canFire = true;
    }
}