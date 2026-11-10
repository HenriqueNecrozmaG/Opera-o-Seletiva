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

    void Start()
    {
        GameFacade.Instance.StartGame();
        GameFacade.Instance.UpdateUIMaterialQuantityTexts(plasticQuantity, plasticQuantity, glassQuantity, metalQuantity);
        CurrentState = GameState.Playing;
        Cursor.visible = false;

        time = gameTime;
        GameFacade.Instance.UpdateUITextTime(time);
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

    public void Defeat()
    {
        CurrentState = GameState.Defeat;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        CurrentState = GameState.Victory;
        Cursor.visible = true;
        Time.timeScale = 0f;

        Resources.plastic = plasticQuantity;
        Resources.paper = paperQuantity;
        Resources.glass = glassQuantity;
        Resources.metal = metalQuantity;

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
