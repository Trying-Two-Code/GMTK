// Purpose: This script is used to detect when the player enters the scent zone of a scent object. It is used to trigger the scent object to start emitting scent particles when the player enters the scent zone. The player can then choose to smell the area and an audio clip will play. The scent object will then stop emitting scent particles. This script is attached to the scent zone object.

using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class ScentZone : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip smellSound;

    [Header("Scaling Settings")]
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2.0f;

    private ParticleSystem scentParticles;
    private TextMeshProUGUI hint;
    private GameObject nose;
    private bool playerInZone = false;
    private bool smelling = false;
    private float[] samples = new float[256];
    

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
                hint.text = "";
                audioSource.PlayOneShot(smellSound);
            }
        }

        if (audioSource.isPlaying)
        {
            audioSource.GetOutputData(samples, 0);

            // Calculate RMS value
            float sum = 0f;
            for (int i = 0; i < samples.Length; i++)
            {
                sum += samples[i] * samples[i];
            }
            float rmsValue = Mathf.Sqrt(sum / samples.Length);

            // Normalize RMS value to a 0-1 range
            float normalizedVolume = Mathf.Clamp01(rmsValue / 0.1f);

            // Scale the nose based on the normalized volume
            float scale = Mathf.Lerp(minScale, maxScale, normalizedVolume);
            nose.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            hint = other.GetComponentInChildren<Canvas>().transform.Find("Hint").GetComponent<TextMeshProUGUI>();
            nose = other.transform.Find("Gimbal").transform.Find("Camera").transform.Find("Nose").gameObject;
            if (!smelling)
            {
                hint.text = "Press E to smell";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            hint.text = "";
        }
    }
}
