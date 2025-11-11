using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * Chase Phillips
 * 11/5/25
 * Handles the effects/attacks of the boss.
 */

public class Surprise : MonoBehaviour
{

    public ParticleSystem slamSmoke; //For effects that will spawn to enchance the shockwave of the slam. 

    public GameObject smokeSpawn;
    public GameObject smokeSpawn1;
    public GameObject smokeSpawn2;
    public GameObject smokeSpawn3;

    public Enemy enemy;//Needed for the health value check.
    public Vector3 axis = Vector3.back;//Axis to rotate around.
    public float degrees = -15f;//How far to roatate.
    public float duration = 1f;//How long rotation takes.
    public float returnDuration = 0.5f;//How quickly the slam happens.

    private Quaternion origonalRotation;



    private bool isRotating = false; //Check to make sure the animation is playing.
    public bool shockwave; //Fires a tigger once every time the slam happens.

    // Start is called before the first frame update
    void Start()
    {
        origonalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy.health < 500) //Check if the boss has been damaged by the player yet, if not action remains idle.
        {
            if (!isRotating)
            {
                StartCoroutine(Slam());
            }
        }
    }

    private IEnumerator Slam()
    {
        isRotating = true;
        Quaternion startRotation = origonalRotation;
        Quaternion targetRotation = Quaternion.AngleAxis(degrees, axis) * startRotation;

        //The cooldown for the boss to use this ability.
        float seconds = UnityEngine.Random.Range(5, 10);
        yield return new WaitForSeconds(seconds);

        yield return StartCoroutine(Rotate(startRotation, targetRotation, duration)); //Rotates up
        yield return new WaitForSeconds(1); //Waits for a second at peak rotation.
        yield return StartCoroutine(Rotate(targetRotation, startRotation, returnDuration));//Slams down

        //Particles for dramtic effect
        Instantiate(slamSmoke, smokeSpawn.transform.position, Quaternion.Euler(-90, 0, 0));
        Instantiate(slamSmoke, smokeSpawn1.transform.position, Quaternion.Euler(-90, 0, 0));
        Instantiate(slamSmoke, smokeSpawn2.transform.position, Quaternion.Euler(-90, 0, 0));
        Instantiate(slamSmoke, smokeSpawn3.transform.position, Quaternion.Euler(-90, 0, 0));

        isRotating = false;
        shockwave = true;



    }

    private IEnumerator Rotate(Quaternion from, Quaternion to, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            float t = elapsed / time;
            transform.rotation = Quaternion.Slerp(from, to, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }
}
