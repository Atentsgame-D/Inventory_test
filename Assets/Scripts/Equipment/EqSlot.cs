using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EqSlot : Slot
{
    public EquimentType equimentType;
    public ArmorType armorType;
    public WeapnType weapnType;

    public override void ChangeSlot()
    {        
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        if (armorType == DragSlot.Inst.dragSlot.item.armorType)
        {
            AddItem(DragSlot.Inst.dragSlot.item, DragSlot.Inst.dragSlot.itemCount);

            if (_tempItem != null)
                DragSlot.Inst.dragSlot.AddItem(_tempItem, _tempItemCount);
            else
                DragSlot.Inst.dragSlot.ClearSlot();
        }
    }
}
