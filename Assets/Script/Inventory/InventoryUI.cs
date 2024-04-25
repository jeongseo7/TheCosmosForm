using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryPanel;
    bool activeInventory = false;
    public Transform slotHolder; // ���� �ø���

    public Slot[] slots;

    private void Start()
    {
        inventory = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        inventory.onSlotCountChange += SlotChange;
        inventory.onChangeItem += RedrawSlotUI;// ����� ������ UI�� ���    
        RedrawSlotUI();
        inventoryPanel.SetActive(activeInventory);
    }

    private void SlotChange(int val)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].slotnum = i;
            if(i< inventory.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;

            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        if (Input.GetMouseButtonUp(0))
        {
           
        }
        
    }


    public void AddSlot()
    {
        inventory.SlotCnt = inventory.SlotCnt + 4; // ���� ���� 

    }
    void RedrawSlotUI()
    {
        // ���� ������ ����� ������ ��� ������ �ٽ� �׸��� ���� ���� ������ ��� �����մϴ�.
        foreach (Slot slot in slots)
        {
            slot.RemoveSlot();
        }

        // �κ��丮�� �ִ� �������� ���Կ� �Ҵ��Ͽ� UI�� ������Ʈ�մϴ�.
        for (int i = 0; i < inventory.SlotCnt; i++)
        {
            // �κ��丮�� �������� �ִ� ��쿡�� �ش� ������ ������Ʈ�մϴ�.
            if (i < inventory.items.Count)
            {
                slots[i].item = inventory.items[i];
                slots[i].UpdateSlotUI();
            }
        }
    }

   

    public void ActiveShop(bool isOpen)
    {
        if (!activeInventory)
        {
            
            inventoryPanel.SetActive(isOpen);
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].isShopMode = isOpen;
            }

        }
    }
    public void DeActiveShop()
    {
        ActiveShop(false);
    }
    public void SellBtn()
    {
        for (int i = slots.Length; i > 0; i--)
        {
            slots[i-1].SellItem();
        }
    }
}
