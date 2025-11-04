using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Checks if what is overlapping is the player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().MissileUpgrade();
            Destroy(gameObject);
        }
    }
}
