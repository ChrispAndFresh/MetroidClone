using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Chris Pimentel
 * 11/11/25
 * Handles UI of End Screens and moving scenes
 */

public class EndGameScreen : MonoBehaviour
{
    public float waitTime = 0.5f;
   

    /// <summary>
    /// Takes the player back to the game when Retry Button is clicked
    /// </summary>
    /// <param name="sceneIndex"></param>
   public void RetryButton(int sceneIndex)
    {
        StartCoroutine(WaitToLoadScene(waitTime, sceneIndex));
    }


    /// <summary>
    /// Quit game when Quit Button is clicked
    /// </summary>
    public void QuitButton()
    {
        StartCoroutine(WaitToEndGame(waitTime));
    }


    /// <summary>
    /// Loads Scenes with slight delay
    /// </summary>
    /// <param name="waitTime"></param>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    public IEnumerator WaitToLoadScene(float waitTime, int sceneIndex)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneIndex);
    }


    /// <summary>
    /// Quits game with slight delay
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    public IEnumerator WaitToEndGame(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }
}
