using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public CharacterObject character;
    public Text characterName;
    public Text characterDescription;
    public Image characterImage;
    public Text characterHealth;
    public Text characterDamage;
    public Text characterSpeed;
    public Text characterDefense;
    public Text characterMana;
    void Start()
    {
        characterName.text = character.characterName;
        characterDescription.text = character.characterDescription;
        characterImage.sprite = character.characterImage;
        characterHealth.text = character.characterHealth.ToString();
        characterDamage.text = character.characterDamage.ToString();
        characterSpeed.text = character.characterSpeed.ToString();
        characterDefense.text = character.characterDefense.ToString();
        characterMana.text = character.characterMana.ToString();
    }

}
