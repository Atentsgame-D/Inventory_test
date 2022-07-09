using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;

    private bool activeInventory = false;
    public bool ActiveInventory { get => activeInventory; }

    private void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }

    private void Update()
    {
        inventoryPanel.SetActive(activeInventory);
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
