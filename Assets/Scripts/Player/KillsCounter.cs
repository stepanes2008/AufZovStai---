using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartTipText;
    public GameObject gameOverScreen;
    public GameObject killsCountText;
    public GameObject levelController;
    public GameObject wolfBody;
    public GameObject Explosion;
    public string killsCounterText = "/50";
    public int maxKills = 50;
    public int Kills = 0;
    public GameObject nextLevelButton;
    public bool Victory = false;

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
        killsCountText.GetComponent<TMP_Text>().text = "Kills: " + Kills.ToString() + killsCounterText;
        if (Kills >= maxKills && !levelController.GetComponent<PauseOnESC>().IsGamePaused)
        {
            wolfBody.GetComponent<Animator>().SetTrigger("Victory");
            nextLevelButton.GetComponent<Button>().interactable = true;
            gameOverScreen.SetActive(true);
            gameOverText.GetComponent<TMP_Text>().text = "Victory";
            restartTipText.GetComponent<TMP_Text>().text = "Press ESC to exit to Main Menu";
            Victory = true;
            GetComponent<Move>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            Explosion.GetComponent<SizeIncrease>().Death = true;
            Invoke("DeathPause", 2);
        }
    }
    private void DeathPause()
    {
        Time.timeScale = 0;
    }
}
