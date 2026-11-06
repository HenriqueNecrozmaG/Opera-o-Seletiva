using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory factory;
    
    public void Spawn(EnemyType type)
    {
        factory.CreateEnemy(type, new Vector3(Random.Range(-35f, 35f), -0.9f, 35f));
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
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
        }
    }

}
