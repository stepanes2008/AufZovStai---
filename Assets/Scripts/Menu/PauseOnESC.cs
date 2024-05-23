using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnESC : MonoBehaviour
{
    public GameObject player;
    public GameObject pauseScreen;
    public GameObject gameplayScreen;
    public GameObject gameStatsScreen;
    public GameObject gameOverScreen;
    public bool IsGamePaused = false;
    private bool canPlay = true;

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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            gameOverScreen.SetActive(false);
            pauseScreen.SetActive(true);
            gameStatsScreen.SetActive(false);
            Time.timeScale = 0;
            if (player.GetComponent<PlayerHealth>().isDead)
            {
                GetComponent<LevelController>().LoadCurrentLevel();
            }
        }
        if (Time.timeScale == 0)
        {
            GetComponent<AudioSource>().Stop();
            canPlay = true;
        }
        else if (canPlay)
        {
            GetComponent<AudioSource>().Play();
            canPlay = false;
        }
    }
    public void ContinueGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IsGamePaused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
