using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public InventoryObject inventory;


    // Clear inventory on quit so items dont transfer between sessions
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
