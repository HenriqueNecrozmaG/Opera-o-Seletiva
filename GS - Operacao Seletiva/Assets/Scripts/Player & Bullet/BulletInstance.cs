using JetBrains.Annotations;
using UnityEngine;

public class BulletInstance : MonoBehaviour
{
    public BulletStats stats; 

    [SerializeField] private float speed;

    private Rigidbody rb;
    private MeshRenderer render;

    public void Setup(BulletStats stats)
    {
        this.stats = stats;
        name = stats.bulletName;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        render = rb.GetComponent<MeshRenderer>();

        render.material.color = stats.bulletColor;
    }

    void Update()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlasticMonster" && stats.materialIndex == 0)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "PaperMonster" && stats.materialIndex == 1)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "GlassMonster" && stats.materialIndex == 2)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "MetalMonster" && stats.materialIndex == 3)
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
