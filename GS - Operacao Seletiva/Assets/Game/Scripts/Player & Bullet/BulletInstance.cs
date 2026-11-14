using UnityEngine;

public class BulletInstance : MonoBehaviour
{
    public BulletStats stats; 

    [SerializeField] private float speed;
    [SerializeField] private MeshRenderer render;

    [Header("Damage Effects")]
    [SerializeField] private GameObject punchEffectRed;
    [SerializeField] private GameObject punchEffectBlue;
    [SerializeField] private GameObject punchEffectGreen;
    [SerializeField] private GameObject punchEffectYellow;

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
            GameObject damageEffect = Instantiate(punchEffectRed);
            damageEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
            Destroy(damageEffect, 0.5f);
        }
        else if (other.gameObject.tag == "PaperMonster" && stats.materialIndex == 1)
        {
            other.GetComponent<EnemyScript>().Damage();
            GameObject damageEffect = Instantiate(punchEffectBlue);
            damageEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
            Destroy(damageEffect, 0.5f);
        }
        else if (other.gameObject.tag == "GlassMonster" && stats.materialIndex == 2)
        {
            other.GetComponent<EnemyScript>().Damage();
            GameObject damageEffect = Instantiate(punchEffectGreen);
            damageEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
            Destroy(damageEffect, 0.5f);
        }
        else if (other.gameObject.tag == "MetalMonster" && stats.materialIndex == 3)
        {
            other.GetComponent<EnemyScript>().Damage();
            GameObject damageEffect = Instantiate(punchEffectYellow);
            damageEffect.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
            Destroy(damageEffect, 0.5f);
        }
        else
        {
            GameFacade.Instance.PlayAudioSoundEffect(7);
        }

        Destroy(gameObject);
    }
}
