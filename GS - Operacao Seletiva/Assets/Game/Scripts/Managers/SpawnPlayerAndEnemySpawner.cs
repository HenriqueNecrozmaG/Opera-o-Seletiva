using UnityEngine;

public class SpawnPlayerAndEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemySpawnerPrefab;

    public void Spawn()
    {
        Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        Instantiate(enemySpawnerPrefab, enemySpawnerPrefab.transform.position, enemySpawnerPrefab.transform.rotation);
    }
}
