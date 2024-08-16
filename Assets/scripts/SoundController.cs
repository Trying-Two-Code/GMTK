using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private AudioClip[] creepySounds;
    [SerializeField] private AudioClip[] ambientSounds;

    [Header("Components")]
    public CreateSound createSound;
    public Transform Fantom;

    [Header("Variables")]
    //Time spawn is added to how long it takes to spawn in a new sound. This is added to how long the sound lasts so the player has a lot of time in ambience
    public float maxTimeSpawn;
    public float minTimeSpawn;

    //Volume settings
    public float sfxVolume;
    public float ambientVolume;
    public bool mute;
    [SerializeField] private float distortion = 0.1f;

    void MakeCreepySound()
    {
        CreateSound.SFX(creepySounds[Random.Range(0, creepySounds.Length)], sfxVolume, distortion, Fantom);
    }

    private void Update()
    {
        
    }
}
