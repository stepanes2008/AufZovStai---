using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Bye!");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}

