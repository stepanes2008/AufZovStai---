using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool LevelRestarted = false;

    public void LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var newSceneIndex = currentSceneIndex + 1;
        PlayerPrefs.SetInt("currentLevel", newSceneIndex);
        SceneManager.LoadScene(newSceneIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene(1);
    }

    public void LoadCurrentLevel()
    {
        var currentLevel = PlayerPrefs.GetInt("currentLevel");
        Debug.Log(currentLevel);
        SceneManager.LoadScene(currentLevel);
/*        if (LevelRestarted)
        {
            ClosePauseScreen();
        }*/
    }

    public void StartLevel()
    {
        LoadCurrentLevel();
        //Invoke("ClosePauseScreen", 0.5f);
    }


}
