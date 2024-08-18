using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float volume;
    public AudioClip clip;
    [SerializeField] private AudioSource source;
    public Vector2 timeBeforeDeath = new Vector2(1, 10);
    public float timeBeforeDeathProper = 0f;
    public bool loop = false;
    private void Start()
    {
        Invoke("SetAudioSettings", 1f);
        if(timeBeforeDeathProper != 0f)
        {
            Destroy(gameObject, timeBeforeDeathProper);
        }
        else
        {
            Destroy(gameObject, Random.Range(timeBeforeDeath.x, timeBeforeDeath.y));
        }
        
    }

    void SetAudioSettings()
    {
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.Play();
    }
}
