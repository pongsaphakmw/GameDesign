using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float crouchSpeed = 2.0f;
    public float rotationSpeed = 5f;
    public float crouchColliderHeight = 1.35f;
    [Range(0, 1)]
    public float speedDampTime = 0.1f;
    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;
    public CharacterObject character;
    public HealthBar healthBar;
    public ManaBar manaBar;
    public StateMachine movementSM;
    public StandingState standing;
    // public CrouchingState crouching;
    public Animator animator;
    public Vector3 playerVelocity;
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Transform cameraTransform;
    private int currentHealth;
    private int currentMana;
    private Vector2 move;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
    void Start()
    {
        currentHealth = character.characterHealth;
        currentMana = character.characterMana;
        healthBar.SetMaxHealth(character.characterHealth);
        manaBar.SetMaxMana(character.characterMana);

        // Animation
        playerInput = GetComponent<PlayerInput>();
        movementSM = new StateMachine();
        standing = new StandingState(this, movementSM);
        // crouching = new CrouchingState(this, movementSM);
        cameraTransform = Camera.main.transform;
        movementSM.Initialize(standing);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            TakeDamage(10);
        }
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            // Debug.Log("U key was pressed.");
            SkillUsed(10);
        }
        movementSM.currentState.HandleInput();
 
        movementSM.currentState.LogicUpdate();
    }

    public void movePlayer(){
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        // Debug.Log("Current Health: " + currentHealth);
        // Debug.Log("Current Mana: " + currentMana);
    }
    public void SkillUsed(int mana)
    {
        currentMana -= mana;
        manaBar.SetMana(currentMana);
        // Debug.Log("Current Health: " + currentHealth);
        // Debug.Log("Current Mana: " + currentMana);
    }
    private void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
}
