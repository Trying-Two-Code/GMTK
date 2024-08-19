using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject SpawnOnOpen = null;
    public bool AutoClose = false;
    public bool requireKey = false;
    public InventorySlot Key;

    public AudioClip doorCreak;
    public Transform goTo;
    public Transform spawnAt;
    public GameObject MainDoor;
    private Vector3 oldPos;
    public void Open()
    {
        CreateSound.SFX(doorCreak, 1f, 0f, null, 2);

        MainDoor.transform.position = goTo.position;

        if(SpawnOnOpen != null)
        {
            Instantiate(SpawnOnOpen, spawnAt.position, Quaternion.identity);
        }
    }

    private bool opened = false;

    void Close()
    {
        CreateSound.SFX(doorCreak, 1f, 0f, null, 3);

        MainDoor.transform.position = oldPos;
    }

    public void AutoCloseNow(GameObject callingFrom = null)
    {
        if (AutoClose)
        {
            Close();
            requireKey = true;
            AutoClose = false;
        }
        else
        {
            if(callingFrom != null)
            {
                Destroy(callingFrom);
            }
        }
    }


    private void Start()
    {
        oldPos = MainDoor.transform.position;
    }

    public void Interact(PlayerManager player)
    {
        if (requireKey)
        {
            Debug.Log("Checking For Key... " + player.inventory.Container.ToArray());

            
            if(player.inventory.CheckForItem(Key, true))
            {
                Debug.Log("has key");
                requireKey = false;
                CheckForOpenClose();
                AutoClose = false;
            }
        }
        else
        {
            CheckForOpenClose();
        }

        
    }

    void CheckForOpenClose()
    {
        if (!opened)
        {
            Open();
            opened = !opened;
        }
        else
        {
            Close();
            opened = !opened;
        }
    }

}
