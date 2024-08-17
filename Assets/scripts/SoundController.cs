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
    public float minTimeSpawn;
    public float maxTimeSpawn;
    
    //Volume settings
    public float sfxVolume;
    public float ambientVolume;
    [SerializeField] private float distortion = 0.1f;

    void MakeCreepySound()
    {
        Debug.Log("Creating Creepy Sound he he he he....");
        CreateSound.SFX(creepySounds[Random.Range(0, creepySounds.Length)], sfxVolume, distortion, Fantom, new Vector2(1, 10));
    }

    private float waitThisLong = 2f;

    private void Update()
    {
        waitThisLong -= Time.deltaTime;
        if(waitThisLong <= 0)
        {
            waitThisLong = Random.Range(minTimeSpawn, maxTimeSpawn);
            MakeCreepySound();
        }
    }


    public void Mute(bool muting = false)
    {   
        sfxVolume = 0f;
        ambientVolume = 0f;
    }
}
