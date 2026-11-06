using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject plasticPrefab;
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private GameObject glassPrefab;
    [SerializeField] private GameObject metalPrefab;
    
    public GameObject CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject prefab = null;
        
        switch (type)
        {
            case EnemyType.PlasticEnemy: prefab = plasticPrefab; break;
            case EnemyType.PaperEnemy: prefab = paperPrefab; break;
            case EnemyType.GlassEnemy: prefab = glassPrefab; break;
            case EnemyType.MetalEnemy: prefab = metalPrefab; break;
        }
        
        if (prefab == null) return null;
        
        return Instantiate(prefab, position, Quaternion.identity);
    }
}
