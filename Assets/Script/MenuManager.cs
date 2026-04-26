using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("Setting");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
