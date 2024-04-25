using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FieldItem : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.Itemname = _item.Itemname;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;
        item.ItemCost = _item.ItemCost;
        image.sprite = _item.itemImage;

    }

    public Item GetItem()
    {
        return item;
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
