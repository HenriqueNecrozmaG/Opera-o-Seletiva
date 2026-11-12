using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float deathTime;

    private NavMeshAgent agent;
    private Transform target;
    private Animator anim;
    private bool isDead;
    private bool attack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

        agent.speed = speed;
        isDead = false;
    }

    void Update()
    {
        if (isDead)
        {
            agent.acceleration = 1000;
            agent.speed = 0;
        }

        if (gameObject.transform.position.z <= 0)
        {
            attack = true;
        }

        agent.SetDestination(target.position);
        Animate();
    }

    public void Damage()
    {
        health--;

        if (health <= 0)
        {
            health = 0;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        isDead = true;

        if (gameObject.tag == "PlasticMonster")
        {
            GameManager.Instance.AddPlastic();
        }
        else if (gameObject.tag == "PaperMonster")
        {
            GameManager.Instance.AddPaper();
        }
        else if (gameObject.tag == "GlassMonster")
        {
            GameManager.Instance.AddGlass();
        }
        else if (gameObject.tag == "MetalMonster")
        {
            GameManager.Instance.AddMetal();
        }

        yield return new WaitForSeconds(deathTime);

        Destroy(gameObject);
    }

    void Animate()
    {
        anim.SetInteger("pMove", (int)agent.speed);
        anim.SetBool("pDead", isDead);
        anim.SetBool("pAttack", attack);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
