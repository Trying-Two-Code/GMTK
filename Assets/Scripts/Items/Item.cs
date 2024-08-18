// Author: Cooper Reffuge
// Description: SciptableObject to put on GameObjects for items

using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemObject item;
    public void Interact(PlayerManager player)
    {
        player.inventory.AddItem(item, 1, this);
    }

    public void DestroyItem()
    {
        if (item.destroyOnInteract) Destroy(gameObject);
    }
}
