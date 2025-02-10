using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    private List<string> _items = new List<string>();

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(string item)
    {
        _items.Add(item);
        Debug.Log($"Инвентарь: {string.Join(", ", _items)}");
    }
}
