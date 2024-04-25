using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region 싱글톤 

    public static  Inventory instance;
    void Awake()
    {
        if(instance != null)
        {
        Destroy(gameObject);
        return;

        }
        instance = this;
    }

    // Update is called once per frame
    #endregion

    public delegate void OnSlotCountChange(int val);//대리자 정의
    public OnSlotCountChange onSlotCountChange;//인스턴스화
    public List<Item> items = new List<Item>();

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    private int slotCnt;

    public int SlotCnt
    {
        get => slotCnt;
        set 
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }

    }
    void Start()
    {
        SlotCnt = 4; //슬롯활성화 갯수
    }

    public bool AddItem(Item item)
    {
        if(items.Count < slotCnt)
        {
            items.Add(item);
            if (onChangeItem != null)
            {
            onChangeItem.Invoke();
            }
                
            
            return true;
        }
        return false;
    }
    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FieldItem fieldItem = collision.GetComponent<FieldItem>();
            if (AddItem(fieldItem.GetItem()))
                fieldItem.DestroyItem();
        }
    }
}
