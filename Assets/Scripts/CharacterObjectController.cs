using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObjectController : MonoBehaviour
{
    private CharacterObject character;
    private int currentHealth;
    private void Start()
    {
        currentHealth = character.characterHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
