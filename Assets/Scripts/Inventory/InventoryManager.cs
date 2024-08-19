// Author: Cooper Reffuge
// Description: Scriptable object for any inventory, can be used for shops, chests, enemies, etc.

using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class InventoryObject : ScriptableObject
{
    public int inventorySize;
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _amount, Item itemObject = null)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                // Max stack reached, return
                // Else, add to stack
                Container[i].AddAmount(_amount);
                itemObject?.DestroyItem();
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            if (Container.Count + 1 > inventorySize) return;
            Container.Add(new InventorySlot(_item, _amount));
            itemObject?.DestroyItem();
        }
    }
    
    public bool CheckForItem(InventorySlot myItem, bool removeItem = false)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == myItem.item)
            {
                if (removeItem)
                {
                    Container.RemoveAt(i);
                }
                return true;
            }
        }
        return false;
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}