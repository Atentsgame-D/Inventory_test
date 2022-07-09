using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public Player player;
    public Store store;
    private InventoryUI invenUI;
    TextMeshProUGUI useText = null;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        invenUI = GameObject.Find("Canvas").GetComponent<InventoryUI>();
        //useText = GameObject.Find("UseText").GetComponent<TextMeshProUGUI>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (player.tryUse)
        {
            store.HideOff();
            invenUI.OnInventoryOpen();
            //useText.gameObject.SetActive(false);
        }
        else
        {
            store.HideOn();
            invenUI.OnInventoryClose();
            //useText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        store.HideOn();
        invenUI.OnInventoryClose();
        //inventory.HideOn();
    }

}
