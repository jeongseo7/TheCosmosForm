using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public int money = 0;

    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();

    public GameObject fieldItemPrefab;

    private void Start()
    {
        money = 10000;
    }

}
