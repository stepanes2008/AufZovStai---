using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnESC : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameplayScreen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*SceneManager.LoadScene("MenuScene");*/
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
