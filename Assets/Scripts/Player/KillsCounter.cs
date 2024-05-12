using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartTipText;
    public GameObject gameOverScreen;
    public GameObject killsCountText;
    public GameObject levelController;
    public int Kills = 0;

    public int N;

    private void Start()
    {
        int c = 0;
        while (N != 0)
        {
            if (N % 2 == 0)
            {
                N /= 2;
            }
            else
            {
                N = N / 10;
            }
            c++;
        }
        Debug.Log(c);
        Kills = 0;
    }

    void Update()
    {
        killsCountText.GetComponent<TMP_Text>().text = "Kills: " + Kills.ToString() + "/50";
        if (Kills >= 50 && !levelController.GetComponent<PauseOnESC>().IsGamePaused)
        {
            gameOverScreen.SetActive(true);
            gameOverText.GetComponent<TMP_Text>().text = "Victory";
            restartTipText.GetComponent<TMP_Text>().text = "Press ESC to exit to Main Menu";
            Time.timeScale = 0;
        }
    }
}
