using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

interface IInteractable
{
    public void Interact(PlayerManager player);
}

public class Interactions : MonoBehaviour
{
    [HideInInspector] public bool disablePrompt;
    [SerializeField] private Transform interactionSource;
    public static KeyCode interactKey = KeyCode.E;
    public static KeyCode interactKey2 = KeyCode.Space;
    [SerializeField] private float interactRange;
    [SerializeField] private GameObject interactPrompt, swapObject;
    [SerializeField] private PlayerManager plr;

    void Update()
    {
        
        if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(interactKey2) || Input.GetMouseButtonDown(1))
        {
            Ray ray = new Ray(interactionSource.position, interactionSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                if (hit.transform.TryGetComponent(out IInteractable interact))
                {
                    interact.Interact(plr);
                }
            }
        }


        Ray _ray = new Ray(interactionSource.position, interactionSource.forward);
        if (Physics.Raycast(_ray, out RaycastHit _hit, interactRange) && !disablePrompt)
        {
            interactPrompt?.SetActive(_hit.transform.TryGetComponent(out IInteractable i));
            
        }
        else
        {
            interactPrompt?.SetActive(false);
        }
        if(swapObject) swapObject.SetActive(!interactPrompt.activeSelf);
    }
}
