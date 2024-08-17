using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float volume;
    public AudioClip clip;
    [SerializeField] private AudioSource source;
    public Vector2 timeBeforeDeath = new Vector2(1, 10);
    private void Start()
    {
        Invoke("SetAudioSettings", 1f);
        Destroy(gameObject, Random.Range(timeBeforeDeath.x, timeBeforeDeath.y));
    }

    void SetAudioSettings()
    {
        source.clip = clip;
        source.volume = volume;
        source.Play();
    }
}
