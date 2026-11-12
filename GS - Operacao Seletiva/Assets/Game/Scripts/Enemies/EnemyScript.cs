using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float deathTime;

    private float speed;
    private float health;

    private NavMeshAgent agent;
    private Transform target;
    private Animator anim;
    private Collider col;
    private bool isDead;
    private bool attack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();

        speed = DifficultyManager.Instance.enemySpeed;
        health = DifficultyManager.Instance.enemyHealth;

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
        else
        {
            if (gameObject.tag == "PlasticMonster")
            {
                GameFacade.Instance.PlayAudioSoundEffect(1);
            }
            else if (gameObject.tag == "PaperMonster")
            {
                GameFacade.Instance.PlayAudioSoundEffect(2);
            }
            else if (gameObject.tag == "GlassMonster")
            {
                GameFacade.Instance.PlayAudioSoundEffect(3);
            }
            else if (gameObject.tag == "MetalMonster")
            {
                GameFacade.Instance.PlayAudioSoundEffect(4);
            }
        }
    }

    IEnumerator Death()
    {
        isDead = true;
        col.enabled = false;
        GameFacade.Instance.PlayAudioSoundEffect(5);

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
