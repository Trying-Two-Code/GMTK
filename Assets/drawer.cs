using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour, IInteractable
{
    public GameObject target;
    public Transform openTransform;
    private Vector3 oldTransform;

    private void Start()
    {
        oldTransform = transform.position;
    }

    public void Interact(PlayerManager player)
    { 
        
    }

    public void Open()
    {

    }
    public void Close()
    {

    }

}
