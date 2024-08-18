// Purpose: This script is used to detect when the player enters the scent zone of a scent object. It is used to trigger the scent object to start emitting scent particles when the player enters the scent zone. The player can then choose to smell the area and an audio clip will play. The scent object will then stop emitting scent particles. This script is attached to the scent zone object.

using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class ScentZone : MonoBehaviour
{
    public AudioClip smellSound;
    private AudioSource audioSource;
    private ParticleSystem scentParticles;
    private bool playerInZone = false;
    private bool smelling = false;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scentParticles = GetComponentInChildren<ParticleSystem>();
        GetComponent<Collider>().isTrigger = true;
    }

    private void Update()
    {
        if (playerInZone && !smelling)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Smelling");
                smelling = true;
                scentParticles.Stop();
                audioSource.PlayOneShot(smellSound);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}
