using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject gameOverScreen;
    public GameObject killsCountText;
    public GameObject levelController;
    public int Kills = 0;

    private void Start()
    {
        Kills = 0;
    }

    void Update()
    {
        killsCountText.GetComponent<TMP_Text>().text = "Kills: " + Kills.ToString() + "/50";
        Debug.Log("Kills: " + Kills.ToString() + "/50");
        if (Kills >= 50 && !levelController.GetComponent<PauseOnESC>().IsGamePaused)
        {
            gameOverScreen.SetActive(true);
            gameOverText.GetComponent<TMP_Text>().text = "Victory";
            Time.timeScale = 0;
        }
    }
}
