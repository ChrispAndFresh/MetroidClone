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

    public GameObject bullet; //Prefab of bullet

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }


    private void FireGun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

    }

}