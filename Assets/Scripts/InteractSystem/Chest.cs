using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    [SerializeField] private string _promt;
    public string InteractionPromt => _promt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with chest");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        return true;
    }
}
