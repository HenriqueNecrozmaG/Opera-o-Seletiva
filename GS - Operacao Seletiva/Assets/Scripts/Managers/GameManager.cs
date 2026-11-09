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

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        GameFacade.Instance.StartGame();
        CurrentState = GameState.Playing;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (CurrentState == GameState.Playing)
            {
                CurrentState = GameState.Paused;
                Time.timeScale = 0f;
            }
            else if (CurrentState == GameState.Paused)
            {
                CurrentState = GameState.Playing;
                Time.timeScale = 1f;
            }
        }
    }
}
