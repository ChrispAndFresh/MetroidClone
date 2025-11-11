using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using UnityEngine;


/*
 * Chase Phillips
 * 11/5/25
 * Handles the spikes movement and timing
 */


public class Spike : MonoBehaviour
{
    public ParticleSystem spikeParticles; //The prefab of a particle system that will give a visual clue to player of an incoming spike.

    public Enemy IsAlive;

    public GameObject spike;
    public float riseHeight = 5f;
    public float riseSpeed = 3f;

    private bool rising = false;

    private bool isMoving = false;

    private bool canStart;


    private UnityEngine.Vector3 spawnParticles;
    private UnityEngine.Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        canStart = true; //Initialize the spikes to start


        //Alligns all the particlesystems to spawn above the spikes
        spawnParticles = spike.transform.position;
        spawnParticles.y += 5f;
        spawnParticles.x += .5f;


        startPos = spike.transform.position;


    }



    void Update()
    {

        if (IsAlive.health > 0 && IsAlive.health < 500)
        {
            if (canStart && !rising && !isMoving)
            {
                StartCoroutine(WaitToStartSpike());
            }
            else if (rising && !isMoving)
            {
                StartCoroutine(MoveSpike());
            }
        }
        else if (IsAlive.health <= 0)
        {
            //This is here to stop them from doing anything after the boss dies. 


        }






    }
    private IEnumerator WaitToStartSpike()
    {
        canStart = false;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 10));
        Instantiate(spikeParticles, spawnParticles, UnityEngine.Quaternion.Euler(0, 0, 0));
        canStart = true;
        rising = true;
    }

    private IEnumerator MoveSpike()
    {
        isMoving = true;
        UnityEngine.Vector3 targetPos = startPos + UnityEngine.Vector3.up * riseHeight;
        yield return new WaitForSeconds(1);

        while (spike.transform.position.y < targetPos.y)
        {
            spike.transform.position = UnityEngine.Vector3.MoveTowards(spike.transform.position, targetPos, riseSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(2);

        while (spike.transform.position.y > startPos.y)
        {
            spike.transform.position = UnityEngine.Vector3.MoveTowards(spike.transform.position, startPos, riseSpeed * Time.deltaTime);
            yield return null;
        }
        rising = false;
        isMoving = false;

    }
}