using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }

    [Header("Time Settings")]
    [SerializeField] private int easyTime;
    [SerializeField] private int mediumTime;
    [SerializeField] private int hardTime;

    [Header("Enemy Speed Settings")]
    [SerializeField] private float easySpeed;
    [SerializeField] private float mediumSpeed;
    [SerializeField] private float hardSpeed;

    [Header("Spawn Time Settings")]
    [SerializeField] private float easySpawnTime;
    [SerializeField] private float mediumSpawnTime;
    [SerializeField] private float hardSpawnTime;

    [Header("Enemy Health Settings")]
    [SerializeField] private float mediumHealth;
    [SerializeField] private float hardHealth;

    [HideInInspector] public int gameTime;
    [HideInInspector] public float enemySpeed;
    [HideInInspector] public float enemySpawnTime;
    [HideInInspector] public float enemyHealth;

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
        GameFacade.Instance.ShowUIDifficultyPanel(easyTime, mediumTime, hardTime);
    }

    public void Easy()
    {
        gameTime = easyTime;
        enemySpeed = easySpeed;
        enemySpawnTime = easySpawnTime;
        enemyHealth = mediumHealth;
        GameManager.Instance.StartGame();
    }

    public void Medium()
    {
        gameTime = mediumTime;
        enemySpeed = mediumSpeed;
        enemySpawnTime = mediumSpawnTime;
        enemyHealth = mediumHealth;
        GameManager.Instance.StartGame();
    }

    public void Hard()
    {
        gameTime = hardTime;
        enemySpeed = hardSpeed;
        enemySpawnTime = hardSpawnTime;
        enemyHealth = hardHealth;
        GameManager.Instance.StartGame();
    }
}
