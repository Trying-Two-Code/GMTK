// Author: Cooper Reffuge
// Description: SciptableObject to put on GameObjects for items

using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public AudioClip OnCollectSFX;
    public ItemObject item;
    public GameObject DestroyThis;
    public void Interact(PlayerManager player)
    {
        if(OnCollectSFX != null)
        {
            CreateSound.SFX(OnCollectSFX, .5f, 0, null, 3f);
        }

        player.inventory.AddItem(item, 1, this);
        Debug.Log("ADDED, current inventory: " + player.inventory.Container.ToArray());
        if(DestroyThis != null)
        {
            Destroy(DestroyThis);
        }
    }

    public void DestroyItem()
    {
        if (item.destroyOnInteract) Destroy(gameObject);
    }
}
