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
}
