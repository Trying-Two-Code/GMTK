// Author: Cooper Reffuge
// Description: idfc

using UnityEngine;

[CreateAssetMenu(fileName = "New Generic Object", menuName = "Create New Item/Generic")]
public class GenericObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.Generic;
    }

}