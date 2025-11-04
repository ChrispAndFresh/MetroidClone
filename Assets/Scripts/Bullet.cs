using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed; //Controls bullet speed
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, 1f, 0f) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If other is an enemy, damage them



        //Checks if what the bullet is overlapping with is NOT the player or gun
        if (other.gameObject.GetComponent<GunController>() == null && other.gameObject.GetComponent<PlayerController>() == null)
        {
            //If the overlapped object is NOT the player or gun, destory the bullet
            Destroy(gameObject);
        }
    }
}
