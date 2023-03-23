using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterObject : ScriptableObject
{
    public string characterName;
    public string characterDescription;
    public Sprite characterImage;
    public int characterHealth;
    public int characterDamage;
    public float characterSpeed;
    public int characterDefense;
    public int characterMana;
}
