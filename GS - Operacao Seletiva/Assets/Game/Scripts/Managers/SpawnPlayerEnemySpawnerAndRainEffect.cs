using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlayerEnemySpawnerAndRainEffect : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemySpawnerPrefab;
    [SerializeField] private GameObject rainEffect;

    public void Spawn()
    {
        Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
        Instantiate(enemySpawnerPrefab, enemySpawnerPrefab.transform.position, enemySpawnerPrefab.transform.rotation);
        Instantiate(rainEffect, rainEffect.transform.position, rainEffect.transform.rotation);
    }
}
