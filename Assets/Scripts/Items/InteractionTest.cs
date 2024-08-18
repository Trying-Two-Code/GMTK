using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    public void Interact(PlayerManager player)
    {
        Debug.Log("HURRAY! " + player.name);
    }
}
