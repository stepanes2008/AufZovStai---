﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnESC : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameplayScreen;
    public GameObject gameStatsScreen;
    public GameObject gameOverScreen;
    public bool IsGamePaused = false;

    private void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*SceneManager.LoadScene("MenuScene");*/
            IsGamePaused = true;
            gameOverScreen.SetActive(false);
            pauseScreen.SetActive(true);
            gameStatsScreen.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void ContinueGame()
    {
        IsGamePaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
