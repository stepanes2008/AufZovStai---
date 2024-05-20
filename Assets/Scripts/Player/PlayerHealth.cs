using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public RectTransform valueRectTransform;
    public GameObject gameOverScreen;
    public GameObject gameOverText;
    public GameObject restartTipText;

    public GameObject playerBody;

    public float value = 100;
    public float _time = 0f;
    public float _maxValue;
    public bool isDead = false;

    
    void Start()
    {
        isDead = false;
    }
    public void DealDamage(float damage, GameObject enemy)
    {
        if (enemy.tag == "Enemy")
        {
            value -= damage;
        }
        if (value <= 0)
        {
            DestroySelf();
        }
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector3(value / _maxValue, 1);
    }
    public void DestroySelf()
    {
        Debug.Log(value);
        isDead = true;
        gameOverScreen.SetActive(true);
        gameOverText.GetComponent<TMP_Text>().text = "Game Over";
        restartTipText.GetComponent<TMP_Text>().text = "Press ESC to restart level";
        playerBody.GetComponent<Animator>().SetTrigger("Death");
        GetComponent<Move>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        Invoke("DeathPause", 2);
    }
    private void DeathPause()
    {
        Debug.Log("+");
        Time.timeScale = 0;
    }
}
