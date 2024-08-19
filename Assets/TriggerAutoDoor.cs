using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAutoDoor : MonoBehaviour
{
    [SerializeField] private Door myDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            myDoor.AutoCloseNow(gameObject);
        }
    }
}
