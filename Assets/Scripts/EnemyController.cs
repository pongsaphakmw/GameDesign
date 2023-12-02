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
    public float attackDelay = 2f;
    public CharacterObject character;
    public HealthBar healthBar;
    public Animator animator;
    public bool isBoss;
    private int currentHealth;
    private bool isAttacking = false;
    Transform target;
    NavMeshAgent agent;
    [SerializeField]
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = character.characterHealth;
        healthBar.SetMaxHealth(character.characterHealth);
        target = PlayerManager.instance.player.transform;
        player = PlayerManager.instance.player.GetComponent<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            if (isBoss)
            {
                Debug.Log("You Win");
            }
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            
                if (distance <= attackRange)
                {
                    if (!isAttacking)
                    {
                        isAttacking = true;
                        StartCoroutine(AttackWithDelay(attackDelay));
                    }
                }
                
                FaceTarget();
            
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
    if (player != null && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
    {
        player.TakeDamage(character.characterDamage);
    }
}
    IEnumerator AttackWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Attack();
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
