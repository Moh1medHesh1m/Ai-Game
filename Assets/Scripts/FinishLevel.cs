using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinishLevel : MonoBehaviour
{

    public GameObject levelMusic;
    public AudioSource levelComplete;
    public GameObject levelTimer;
    public GameObject timeleft;
    public GameObject theScore;
    public GameObject totalScore;
    public int timeCalc;
    public int scoreCalc;
    public int totalScored;
    public GameObject LevelBlocker;
    public GameObject fadeOut;

    void onStart()
    {
    }
    void OnTriggerEnter()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enime");
        foreach (GameObject go in gos)
        {
            go.SetActive(false);
        }

        // GameObject varGameObject = GameObject.FindWithTag("Enime");
        // varGameObject.GetComponent<AiFollow>().enabled = false;


        GetComponent<BoxCollider>().enabled = false;
        LevelBlocker.SetActive(true);
        LevelBlocker.transform.parent = null;
        timeCalc = GlobalTimer.extendScore * 100;
        timeleft.GetComponent<Text>().text = "Time Left: " + GlobalTimer.extendScore + "x 100";
        theScore.GetComponent<Text>().text = "Score: " + GlobalScore.currentScore;
        totalScored = GlobalScore.currentScore + timeCalc;
        totalScore.GetComponent<Text>().text = "Total Score: " + totalScored;
        levelMusic.SetActive(false);
        levelTimer.SetActive(false);
        levelComplete.Play();
        StartCoroutine(CalculateScore());
    }
    IEnumerator CalculateScore()
    {
        timeleft.SetActive(true);
        yield return new WaitForSeconds(1);
        theScore.SetActive(true);
        yield return new WaitForSeconds(1);
        totalScore.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(RedirectToLevel.nextLevel);
    }

}