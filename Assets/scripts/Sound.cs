using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float volume;
    public AudioClip clip;
    [SerializeField] private AudioSource source;

    private void Start()
    {
        Invoke("SetAudioSettings", 1f);
    }

    void SetAudioSettings()
    {
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }
}
