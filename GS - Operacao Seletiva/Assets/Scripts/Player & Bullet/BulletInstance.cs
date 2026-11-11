using UnityEngine;

public class BulletInstance : MonoBehaviour
{
    public BulletStats stats; 

    [SerializeField] private float speed;
    [SerializeField] private MeshRenderer render;

    private Rigidbody rb;

    public void Setup(BulletStats stats)
    {
        this.stats = stats;
        name = stats.bulletName;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        render.material = stats.bulletMaterial;
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlasticMonster" && stats.materialIndex == 0)
        {
            other.GetComponent<EnemyScript>().Damage();
        }
        else if (other.gameObject.tag == "PaperMonster" && stats.materialIndex == 1)
        {
            other.GetComponent<EnemyScript>().Damage();
        }
        else if (other.gameObject.tag == "GlassMonster" && stats.materialIndex == 2)
        {
            other.GetComponent<EnemyScript>().Damage();
        }
        else if (other.gameObject.tag == "MetalMonster" && stats.materialIndex == 3)
        {
            other.GetComponent<EnemyScript>().Damage();
        }

        Destroy(gameObject);
    }
}
