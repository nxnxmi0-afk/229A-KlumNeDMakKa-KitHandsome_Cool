using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEnd : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

}
