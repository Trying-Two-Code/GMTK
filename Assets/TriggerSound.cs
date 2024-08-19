using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip thisSound;
    public bool die = true;
    public float volume = 1f;
    public Transform goHere = null;
    public float delay = 0f;

    private void OnTriggerEnter(Collider _other)
    {
        other = _other;
        if(delay > 0)
        {
            Invoke("DoAllat", delay);
        }
        else
        {
            DoAllat();
        }
    }

    private Collider other;
    void DoAllat()
    {
        Debug.Log("I hit something: " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            CreateSound.SFX(thisSound, volume, 0f, goHere, 25f);
            if (die)
            {
                Destroy(gameObject);
            }
            else
            {
                enabled = false;
            }

        }
    }

}
