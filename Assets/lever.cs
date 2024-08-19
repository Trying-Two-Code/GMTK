using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour, IInteractable
{
    public GameObject movedObject;
    public Transform newPosition;
    public AudioClip sfx;
    public void Interact(PlayerManager player)
    {
        movedObject.transform.position = newPosition.position;
        
        if(sfx != null)
        {
            CreateSound.SFX(sfx, 1f, 0, null, 1f);
        }
        Destroy(gameObject);
    }

}
