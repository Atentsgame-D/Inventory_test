using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public enum SlotType
    {
        Inventory = 0,
        Equipment,
        Store
    }

    public Item item = null;       // 획든한 아이템
    public int itemCount;   // 획득한 아이템의 개수
    public Image itemImage; // 아이템의 이미지
    public SlotType slotType = SlotType.Inventory; 

    // 필요한 컴포넌트
    [SerializeField]
    private TextMeshProUGUI text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private Vector3 originPos = Vector3.zero;

    //private WeaponManager weaponManager;      // 이게 필요한데 아직 안만들었고

    public Slot()
    {

    }

    private void Start()
    {
        originPos = transform.position;
        //weaponManager = FindObjectOfType<WeaponManager>();    // 만들고 하자
    }

    // 이미지의 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if(item.itemType != ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }

    // 아이템 개수 조정
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    // 슬롯 초기화
    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    // 클릭 했을때
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)  // 우클릭 이벤트
        {
            if(item != null)
            {
                if(item.itemType == ItemType.Equipment)
                {
                    // 장착
                    // 만들지 안만들지는 모르겠지만 일단 넣어놓자
                    //StartCoroutine(weaponManager.ChangeWeaponCoroutine(item.weaponType, item.itemName);
                }
                else
                {
                    if (slotType == SlotType.Inventory)
                    {
                        Debug.Log(item.itemName + " 을 사용했습니다");
                        SetSlotCount(-1);
                    }
                    else
                    {
                        // 상점일때 구입창이 뜨도록 하자.
                    }
                }
            }
        }
    }

    //드래그를 시작할때
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.Inst.dragSlot = this;
            DragSlot.Inst.DragSetImage(itemImage);

            DragSlot.Inst.transform.position = eventData.position;
        }
    }

    // 드래그 도중일때
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.Inst.transform.position = eventData.position;
        }
    }

    // 드래그를 끝냈을때
    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.Inst.SetColor(0);
        DragSlot.Inst.dragSlot = null;
    }

    // 포인터를 드랍했을때
    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.Inst.dragSlot != null)
            ChangeSlot();
    }

    public virtual void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.Inst.dragSlot.item, DragSlot.Inst.dragSlot.itemCount);

        if(_tempItem != null)
            DragSlot.Inst.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.Inst.dragSlot.ClearSlot();
    }
}
