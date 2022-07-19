using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // 드래그를 시작할때
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    if (item != null)
    //    {
    //        DragSlot.Inst.dragSlot = this;
    //        DragSlot.Inst.DragSetImage(itemImage);

    //        DragSlot.Inst.transform.position = eventData.position;
    //    }
    //}

    //// 드래그 도중일때
    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (item != null)
    //    {
    //        DragSlot.Inst.transform.position = eventData.position;
    //    }
    //}

    //// 드래그를 끝냈을때
    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    DragSlot.Inst.SetColor(0);
    //    DragSlot.Inst.dragSlot = null;
    //}
}
