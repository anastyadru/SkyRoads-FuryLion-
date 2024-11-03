// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;
    [SerializeField] private Text ScoreText;

    public int score;
    public int highscore;

    private bool isBoosted = false;

    public void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        StartCoroutine(UpdateScore());
        UpdateHighScoreText();
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            if (isBoosted)
            {
                score += 2;
            }
            else
            {
                score += 1;
            }

            ScoreText.text = "SCORE: " + score.ToString();
            
            if (score > highscore)
            {
                highscore = score;
                UpdateHighScoreText();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateHighScoreText()
    {
        HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void ToggleBoostedSpeed(bool newIsBoosted)
    {
        isBoosted = newIsBoosted;
    }

    public void AddAsteroidScore()
    {
        score += 5;
        ScoreText.text = "SCORE: " + score.ToString();
        
        if (score > highscore)
        {
            highscore = score;
            UpdateHighScoreText();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleBoostedSpeed(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ToggleBoostedSpeed(false);
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }
}