using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float score;
    public float hiscore;
    public float pointsPerSecond;

    public bool isInc;


    void Start()
    {
        isInc = true;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiscore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isInc)
        {
            score += pointsPerSecond * Time.deltaTime;
        }

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("HighScore", hiscore);
        }

        scoreText.text = "Score: " + Mathf.Round(score);
        hiScoreText.text = "High Score: " + Mathf.Round(hiscore);
    }

    public void AddPoints(int pointsToGive)
    {
        score += pointsToGive;
    }
}
