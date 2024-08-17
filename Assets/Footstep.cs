using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip sfx;
    public Transform player;
    void MakeFootSound()
    {
        CreateSound.SFX(sfx, 1f, 0f, player, new Vector2(3, 3));
    }

    private void Start()
    {
        InvokeRepeating("MakeFootSound", 1f, .9f);
    }

}
