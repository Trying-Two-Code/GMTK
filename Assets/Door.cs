using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject DestroyThis = null;
    public bool DestroyOnOpen = false;

    public AudioClip canNotOpenSFX;

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
            SpawnOnOpen = null;
        }
    }

    private bool opened = false;

    public void Close()
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
            DestroyOnOpen = true;
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
    public bool setAutoOff = true;
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
                if (setAutoOff)
                {
                    AutoClose = false;
                }
                
                if (DestroyOnOpen)
                {
                    if(DestroyThis != null)
                    {
                        Destroy(DestroyThis);
                    }
                    
                }
            }
            else
            {
                CreateSound.SFX(canNotOpenSFX, 1f, 0, transform, 2f);
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
