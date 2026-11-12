using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToBase()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void Options()
    {
        Debug.Log("Open options menu");
    }

    public void Controls()
    {
        Debug.Log("Open controls menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
