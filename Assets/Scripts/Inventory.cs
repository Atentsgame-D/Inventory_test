using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase = null;
    [SerializeField]
    private GameObject go_SlotsParent = null;

    private Slot[] slots = null;

    private void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    public void AcquireItem(Item _item, int _count)
    {
        if (Item.ItemType.Equipment != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }                
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                if (slots[i].item.itemName == "")
                {
                    slots[i].AddItem(_item, _count);
                    return;
                }
            }
        }
    }
}
