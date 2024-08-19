using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip thisSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateSound.SFX(thisSound, 1f, 0f, null, 10f);
    }
}
