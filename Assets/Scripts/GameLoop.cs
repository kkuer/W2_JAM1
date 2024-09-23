using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public SpawnItems spawnItems;

    public GameObject mailBox;
    public GameObject incinerator;

    public Image fadeIn;
    public Color fadeTo;

    public int score = 0;

    public float timeLeft;
    public bool timerOn = false;

    public TMP_Text timerText;
    public TMP_Text scoreText;

    public GameObject gameplayUI;
    public GameObject endScreenUI;

    public TMP_Text finalScore;

    public GameObject scrollingBG;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        StartCoroutine(randomSpawnTime());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fadeIn.color = Color.Lerp(fadeIn.color, fadeTo, 0.05f);

        if (checkTimer())
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                if (timeLeft < 15)
                {
                    timerText.color = Color.red;
                }
                
            }
            else
            {
                Debug.Log("Time Up");
                timeLeft = 0;
                timerOn = false;
                scrollingBG.SetActive(true);
                gameplayUI.SetActive(false);
                finalScore.text = score.ToString();
                endScreenUI.SetActive(true);
            }
        }
        
    }

    public bool checkTimer()
    {
        if (timerOn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void updateScore(int amount)
    {
        score = score + amount;
        scoreText.text = score.ToString();
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator randomSpawnTime()
    {
        while (timerOn)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            spawnItems.spawnRandom();
        }
    }
}
