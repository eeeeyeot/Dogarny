

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int createSlot = 10;
    public GameObject prefab;
    public Transform rootSlot; // slotroot
    public Shop shop;
    private List<Slot> slots;

    bool active = false;

    void Start()
    {

        slots = new List<Slot>();
        int slotCnt = rootSlot.childCount;

        rootSlot.gameObject.AddComponent<GridLayout>();

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();
            slots.Add(slot);
        }

        shop.onSlotClick += BuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        var emptySlot = slots.Find(t =>
        {
            return t.item == null || t.item.itemName == string.Empty;
        });

        var haveSlot = slots.Find(t =>
        {
            return t.item.itemName == item.itemName && t.itemCount < 99;
        });

        if (haveSlot != null && item.itemtype != ItemType.Equipment)
        {
            if (haveSlot.itemCount > 99)
            {
                if (emptySlot != null)
                {
                    emptySlot.SetItem(item);
                }
            }
            haveSlot.itemCount++;
            haveSlot.text_Count.text = haveSlot.itemCount.ToString();
        }
        else
        {
            if (emptySlot != null)
            {
                emptySlot.itemCount++;
                emptySlot.SetItem(item);
            }
        }
    }

    public void Clickinventory()  // OnClick~~~로 바꾸기
    {
        active = !active;
        this.gameObject.SetActive(active);
    }

    public void CreateSlot()
    {
        for (int i = 0; i < createSlot; i++)
        {
            var slot = Instantiate(prefab).GetComponent<Slot>();
            slots.Add(slot);
        }
    }
}
