using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public int slotnum;
    public Item item;
    public Image itemIcon;

    public bool isShopMode;
    public GameObject chkSell;

    public bool isSell = false;


    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);

    }
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(item != null)
        {
            if(!isShopMode)
            {
                bool isUse = item.Use();
                if(isUse)
                {
                    Inventory.instance.RemoveItem(slotnum);
                }
            }
            else
            {   // ����
                isSell = true;
                chkSell.SetActive(isSell);
            }
        }
    }

    public void SellItem()
    {
        if(isSell)
        {
            ItemDatabase.instance.money+=item.ItemCost;
            Inventory.instance.RemoveItem(slotnum);
            isSell = false;
            chkSell.SetActive(isSell);
        }
    }
    public void OnDisable()
    {
        isSell = false;
        chkSell.SetActive(isSell);
    }

}
