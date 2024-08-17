// Author: Cooper Reffuge
// Description: Item base class that all items have

using UnityEngine;

public enum ItemType
{
    Generic
}

public abstract class ItemObject : ScriptableObject
{
    public ItemType type;
    public GameObject prefab;

    [TextArea(15, 20)]
    public string description;
    public bool destroyOnInteract;
}
