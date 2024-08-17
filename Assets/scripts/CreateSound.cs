using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSound : MonoBehaviour
{
    //This script will have a very simple function: Make it easy to create sfx or music in the physical unity project
    
    public GameObject sfxObj;
    public static GameObject staticSfxObject;

    private void Start()
    {
        staticSfxObject = sfxObj;
    }

    public static void SFX(AudioClip clip, float volume, float distortion, Transform parent, Vector2 timeBeforeDeath)
    {
        //create object
        GameObject soundObject = Instantiate(staticSfxObject, parent);

        //give the sound component it's variables
        Sound soundScript = soundObject.GetComponent<Sound>();
        soundScript.volume = volume;
        soundScript.clip = clip;
        soundScript.timeBeforeDeath = timeBeforeDeath;
    }

    public static void Ambience()
    {

    }
}
