using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSound : MonoBehaviour
{
    //This script will have a very simple function: Make it easy to create sfx or music in the physical unity project

    public static void SFX(AudioClip clip, float volume, float distortion, GameObject obj, Transform parent)
    {
        //create object
        GameObject soundObject = Instantiate(obj, parent);

        //give the sound component it's variables
        soundObject.GetComponent<Sound>().volume = volume;
        soundObject.GetComponent<Sound>().clip = clip;
    }
}
