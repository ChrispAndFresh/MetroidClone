using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Enemy
{
    public float waitTime = 0.5f;
    public int sceneIndex;


    /// <summary>
    /// Overrides function and allows for scene transition
    /// </summary>
    /// <param name="damage"></param>
    public override void GetDamaged(int damage)
    {
        print("boss is damaged");
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(WaitToLoadScene(waitTime, sceneIndex));
            gameObject.SetActive(false); //Disables enemy after death
            Instantiate(healthDrop, transform.position, transform.rotation);
        }
    }


    /// <summary>
    /// Loads scene with slight delay
    /// </summary>
    /// <param name="waitTime"></param>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    public IEnumerator WaitToLoadScene(float waitTime, int sceneIndex)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
