using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance { get; private set; }

    [SerializeField] private int easyTime;
    [SerializeField] private int mediumTime;
    [SerializeField] private int hardTime;

    [SerializeField] private float easySpeed;
    [SerializeField] private float mediumSpeed;
    [SerializeField] private float hardSpeed;

    [SerializeField] private float mediumHealth;
    [SerializeField] private float hardHealth;

    public float gameTime;
    public float enemySpeed;
    public float enemyHealth;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
    }

    public void Easy()
    {
        gameTime = easyTime;
        enemySpeed = easySpeed;
        enemyHealth = mediumHealth;
    }

    public void Medium()
    {
        gameTime = mediumTime;
        enemySpeed = mediumSpeed;
        enemyHealth = mediumHealth;
    }

    public void Hard()
    {
        gameTime = hardTime;
        enemySpeed = hardSpeed;
        enemyHealth = hardHealth;
    }
}
