using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float health;

    private NavMeshAgent agent;
    private Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = speed;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void Damage()
    {
        health--;

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
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
