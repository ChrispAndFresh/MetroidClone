using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/6/25
 * Allows for teleporting between rooms/levels using doors
 */

public class Door : MonoBehaviour
{
    //Reference to the point the door teleports you to
    public Transform teleportPoint;


    private void OnCollisionEnter(Collision collision)
    {
        //Checks if what is colliding is the player
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Teleports player to teleportPoint
            collision.gameObject.transform.position = teleportPoint.position;
        }
    }
}
