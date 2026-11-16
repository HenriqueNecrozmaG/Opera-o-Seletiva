using UnityEngine;
using UnityEngine.SceneManagement;

public enum BaseState
{
    Playing,
    Paused
}

public class BaseManager : MonoBehaviour
{
    public static BaseManager Instance { get; private set; }
    public BaseState CurrentState { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        BaseFacade.Instance.StartBaseScene();
        BaseFacade.Instance.UpdateUIResourcesText(Resources.plastic, Resources.paper, Resources.glass, Resources.metal, Resources.money);
        BaseFacade.Instance.MusicPlay(0);
        CurrentState = BaseState.Playing;
    }

    void Update()
    {
        Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BaseFacade.Instance.PlayAudioSoundEffect(0);

            if (CurrentState == BaseState.Playing)
            {
                BaseFacade.Instance.ShowUIPausePanel();
                CurrentState = BaseState.Paused;
                BaseFacade.Instance.MusicPause();
                Time.timeScale = 0f;
            }
            else if (CurrentState == BaseState.Paused)
            {
                BaseFacade.Instance.HideUIPausePanel();
                BaseFacade.Instance.HideUIOptionsPanel();
                CurrentState = BaseState.Playing;
                BaseFacade.Instance.MusicUnPause();
                Time.timeScale = 1f;
            }
        }
    }

    public void Unpause()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        BaseFacade.Instance.HideUIPausePanel();
        BaseFacade.Instance.HideUIOptionsPanel();
        CurrentState = BaseState.Playing;
        BaseFacade.Instance.MusicUnPause();
        Time.timeScale = 1f;
    }

    public void Options()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        BaseFacade.Instance.ShowUIOptionsPanel();
    }

    public void CloseOptions()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        BaseFacade.Instance.HideUIOptionsPanel();
    }

    public void Return()
    {
        BaseFacade.Instance.PlayAudioSoundEffect(0);
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartScene");
    }
}
