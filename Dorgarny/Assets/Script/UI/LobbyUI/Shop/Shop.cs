using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public Transform slotRoot;
    private List<Slot> slots;
    public List<ItemInfo> shopItems = new List<ItemInfo>();

    public System.Action<ItemInfo> onSlotClick;

    bool active = false;

    void Start()
    {
        ItemManager.Instance.Init();  // 나중에 매니저로 
        slots = new List<Slot>();
        int slotCnt = slotRoot.childCount;

        shopItems.Add(ItemManager.Instance.Find("potion_heal_001"));
        shopItems.Add(ItemManager.Instance.Find("potion_heal_002"));


        for (int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < shopItems.Count)
            {
                
                slot.SetItem(shopItems[i]);
            }
            else
            {
                slot.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }

            slots.Add(slot);
        }
    }
    public void Clickshop()
    {
        active = !active;
        this.gameObject.SetActive(active);
    }

    public void OnClickSlot(Slot slot)
    {
        if (onSlotClick != null)
        {
            if (GoldManager.Instance.Gold >= slot.item.price)
            {
                Debug.Log(slot.item.price);
                onSlotClick(slot.item);
                GoldManager.Instance.Gold = -(slot.item.price);
            }
        }
    }
}
