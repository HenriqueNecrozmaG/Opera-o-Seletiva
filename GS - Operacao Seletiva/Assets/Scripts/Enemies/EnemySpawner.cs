using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory factory;
    [SerializeField] private float spawnTime;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public void Spawn(EnemyType type)
    {
        factory.CreateEnemy(type, new Vector3(Random.Range(-25f, 25f), -0.9f, 72f));
    }
    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spawn(EnemyType.PlasticEnemy);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Spawn(EnemyType.PaperEnemy);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Spawn(EnemyType.GlassEnemy);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Spawn(EnemyType.MetalEnemy);
        }*/
    }

    IEnumerator SpawnCoroutine()
    {
        int spawnIndex = 0;

        yield return new WaitForSeconds(spawnTime);

        spawnIndex = Random.Range(0, 4);

        if (spawnIndex == 0)
        {
            Spawn(EnemyType.PlasticEnemy);
        }
        else if (spawnIndex == 1)
        {
            Spawn(EnemyType.PaperEnemy);
        }
        else if (spawnIndex == 2)
        {
            Spawn(EnemyType.GlassEnemy);
        }
        else if (spawnIndex == 3)
        {
            Spawn(EnemyType.MetalEnemy);
        }

        StartCoroutine(SpawnCoroutine());
    }
}
