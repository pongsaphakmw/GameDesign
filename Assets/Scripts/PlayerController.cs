using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public CharacterObject character;
    public HealthBar healthBar;
    public ManaBar manaBar;
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
}
