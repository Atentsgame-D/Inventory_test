using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inven = null;

    private bool activeInventory = false;
    public bool ActiveInventory { get => activeInventory; }

    private void Start()
    {
        inven.SetActive(activeInventory);
    }

    private void Update()
    {
        inven.SetActive(activeInventory);
    }

    public void OnInventoryOpen()
    {
        activeInventory = true;
    }

    public void OnInventoryClose()
    {
        activeInventory = false;
    }
}
