using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
/*
 * Chase Phillips
 * 11/10/25
 * Handles the storing of the particle systems for the debris.
 */

public class Debris : MonoBehaviour
{
    public Surprise trigger;
    public GameObject debris;
    public ParticleSystem particles;
    public ParticleSystem particles1;
    public ParticleSystem particles2;
    private Vector3 startPos;
    private Vector3 targetPos;

    public float riseHeight = 1f;
    public float riseSpeed = 10f;

    private bool isMoving = false;


    void Start()
    {
        startPos = debris.transform.position;
        targetPos = startPos + Vector3.up * riseHeight;

    }
    void Update()
    {

        if (trigger.shockwave && !isMoving)
        {
            StartCoroutine(MoveDebris());
        }



    }
    private IEnumerator MoveDebris()
    {
        isMoving = true;
        playparticles();
        yield return new WaitForSeconds(1);

        while (debris.transform.position.y < targetPos.y)
        {
            debris.transform.position = Vector3.MoveTowards(debris.transform.position, targetPos, riseSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        while (debris.transform.position.y > startPos.y)
        {
            debris.transform.position = Vector3.MoveTowards(debris.transform.position, startPos, riseSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        trigger.shockwave = false;



    }
    public void playparticles()
    {
        particles.Play();
        particles1.Play();
        particles2.Play();
    }
}
