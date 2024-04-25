using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum ItemType
    {
        Equipment,
        Consumables,
        Etc
    }

    [System.Serializable]
public class Item 
{
    public ItemType itemType;
    public string Itemname;
    public Sprite itemImage;
    public int ItemCost;
    public bool Use()
    {
        bool isUsed = false;
        isUsed = true;

        return isUsed;
    }

}

