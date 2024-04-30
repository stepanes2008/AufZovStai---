using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnESC : MonoBehaviour
{
    public GameObject pauseScreen;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*SceneManager.LoadScene("MenuScene");*/
            pauseScreen.SetActive(true);
        }
    }
    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
