using System.Collections;
using UnityEngine;

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

    [SerializeField] private int gameTime;

    public int plasticQuantity, paperQuantity, glassQuantity, metalQuantity;

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

    void Start()
    {
        GameFacade.Instance.StartGame();
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, plasticQuantity, glassQuantity, metalQuantity);
        CurrentState = GameState.Playing;
        Cursor.visible = false;

        time = gameTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState == GameState.Playing)
            {
                CurrentState = GameState.Paused;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else if (CurrentState == GameState.Paused)
            {
                CurrentState = GameState.Playing;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
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

    public void Defeat()
    {
        CurrentState = GameState.Defeat;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1);

        time--;

        if (time <= 0)
        {
            time = 0;
            CurrentState = GameState.Victory;
            Time.timeScale = 0f;
            yield return null;
        }

        print("Corroutine has started again");
        StartCoroutine(CountTime());
    }
}
