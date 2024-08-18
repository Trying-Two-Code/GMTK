using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioClip doorCreak;
    void Open()
    {
        CreateSound.SFX(doorCreak, .1f, 0f, null, new Vector2(1, 3));

        Debug.Log("Door Open Not Finished: Double Click to Fix");
        Destroy(gameObject);
    }

    void Close()
    {

    }
}
