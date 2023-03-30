using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 5f;
    public float speedDampTime = 0.1f;
    public float velocityDampTime = 0.9f;
    public float rotationDampTime = 0.2f;
    public float attackRange;
    public float lookRadius = 5f;
    public CharacterObject character;
    public HealthBar healthBar;
    public Animator animator;
    private int currentHealth;
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = character.characterHealth;
        healthBar.SetMaxHealth(character.characterHealth);
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        
        currentHealth -= (int)damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Current Health: " + currentHealth);
    }
    public void Attack()
    {
        Debug.Log("Enemy Attacked");
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
