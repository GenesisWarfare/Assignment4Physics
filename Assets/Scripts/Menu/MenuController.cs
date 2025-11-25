using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int gameSceneIndex = 1;

    public void StartGame()
    {
        if (gameSceneIndex >= 0 && gameSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(gameSceneIndex);
        }
        else
        {
            Debug.LogError("Scene index out of range! Check Build Settings.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
