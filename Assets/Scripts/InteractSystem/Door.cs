using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _promt;
    public string InteractionPromt => _promt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with door");
        return true;
    }
}

