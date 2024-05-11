using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    public GameObject killsCountText;
    public int Kills = 0;

    void Update()
    {
        killsCountText.GetComponent<TMP_Text>().text = "Kills: " + Kills.ToString() + "/50";
        Debug.Log("Kills: " + Kills.ToString() + "/50");
    }
}
