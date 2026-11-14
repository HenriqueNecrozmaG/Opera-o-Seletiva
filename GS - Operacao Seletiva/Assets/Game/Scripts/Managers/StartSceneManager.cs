using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private GameObject panelOptions;

    void Start()
    {
        musicManager.Play(0);
        panelOptions.SetActive(false);
    }

    public void Play()
    {
        audioManager.PlaySoundEffect(0);
        SceneManager.LoadScene("GameScene");
    }

    public void GoToBase()
    {
        audioManager.PlaySoundEffect(0);
        SceneManager.LoadScene("BaseScene");
    }

    public void Options()
    {
        audioManager.PlaySoundEffect(0);
        panelOptions.SetActive(true);
    }
    
    public void CloseOptions()
    {
        audioManager.PlaySoundEffect(0);
        panelOptions.SetActive(false);
    }

    public void Controls()
    {
        audioManager.PlaySoundEffect(0);
        Debug.Log("Open controls menu");
    }

    public void Quit()
    {
        audioManager.PlaySoundEffect(0);
        Application.Quit();
    }
}
