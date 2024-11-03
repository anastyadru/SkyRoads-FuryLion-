// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text HighScoreText;

    private void Start()
    {
        // Загружаем лучший счет из PlayerPrefs
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        HighScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}