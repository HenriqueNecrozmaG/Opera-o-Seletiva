using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Playing,
    Paused,
    Victory,
    Defeat
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    [HideInInspector] public int plasticQuantity, paperQuantity, glassQuantity, metalQuantity;

    private int time;

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

    public void StartGame()
    {
        GameFacade.Instance.StartGame();
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, plasticQuantity, glassQuantity, metalQuantity);
        CurrentState = GameState.Playing;
        Cursor.visible = false;

        time = DifficultyManager.Instance.gameTime;
        GameFacade.Instance.UpdateUITextTime(time);
        GameFacade.Instance.MusicPlay(0);
        StartCoroutine(CountTime());
    }

    void Update()
    {
        Pause();
    }

    public void AddPlastic()
    {
        plasticQuantity++;
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);
    }

    public void AddPaper()
    {
        paperQuantity++;
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);
    }

    public void AddGlass()
    {
        glassQuantity++;
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);
    }

    public void AddMetal()
    {
        metalQuantity++;
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameFacade.Instance.PlayAudioSoundEffect(0);

            if (CurrentState == GameState.Playing)
            {
                GameFacade.Instance.ShowUIPausePanel();
                CurrentState = GameState.Paused;
                Cursor.visible = true;
                GameFacade.Instance.MusicPause();
                Time.timeScale = 0f;
            }
            else if (CurrentState == GameState.Paused)
            {
                GameFacade.Instance.HideUIPausePanel();
                CurrentState = GameState.Playing;
                Cursor.visible = false;
                GameFacade.Instance.MusicUnPause();
                Time.timeScale = 1f;
            }
        }
    }

    public void Unpause()
    {
        GameFacade.Instance.PlayAudioSoundEffect(0);
        GameFacade.Instance.HideUIPausePanel();
        CurrentState = GameState.Playing;
        Cursor.visible = false;
        GameFacade.Instance.MusicUnPause();
        Time.timeScale = 1f;
    }

    public void Options()
    {
        GameFacade.Instance.PlayAudioSoundEffect(0);
        Debug.Log("Open options menu");
    }

    public void Return()
    {
        GameFacade.Instance.PlayAudioSoundEffect(0);
        Time.timeScale = 0f;
        SceneManager.LoadScene("StartScene");
    }

    public void Defeat()
    {
        GameFacade.Instance.ShowUIDefeatPanel();
        CurrentState = GameState.Defeat;
        Cursor.visible = true;
        GameFacade.Instance.MusicPlay(2);
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        GameFacade.Instance.ShowUIVictoryPanel();
        CurrentState = GameState.Victory;
        Cursor.visible = true;
        GameFacade.Instance.MusicPlay(1);
        Time.timeScale = 0f;
        GameFacade.Instance.UpdateUIMaterialQuantityVictoryTexts(plasticQuantity, paperQuantity, glassQuantity, metalQuantity);

        Resources.plastic += plasticQuantity;
        Resources.paper += paperQuantity;
        Resources.glass += glassQuantity;
        Resources.metal += metalQuantity;

        print("Plastic: " + Resources.plastic);
        print("Paper: " + Resources.paper);
        print("Glass: " + Resources.glass);
        print("Metal: " + Resources.metal);
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1);

        time--;
        GameFacade.Instance.UpdateUITextTime(time);

        if (time <= 0)
        {
            time = 0;
            Victory();
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(CountTime());
    }
}
