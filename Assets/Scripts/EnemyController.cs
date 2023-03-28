using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 5f;
    public float speedDampTime = 0.1f;
    public float velocityDampTime = 0.9f;
    public float rotationDampTime = 0.2f;
    public CharacterObject character;
    public HealthBar healthBar;
    public Animator animator;
    private int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = character.characterHealth;
        healthBar.SetMaxHealth(character.characterHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
