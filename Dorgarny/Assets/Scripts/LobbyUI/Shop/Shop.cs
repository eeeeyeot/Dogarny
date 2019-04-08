using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public Transform slotRoot;
    public ItemData itemData;
    private List<Slot> slots;

    public System.Action<ItemProperty> onSlotClick;

    bool active = false;

    void Start()
    {

        slots = new List<Slot>();
        int slotCnt = slotRoot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if (i < itemData.items.Count)
            {
                slot.SetItem(itemData.items[i]);

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
            onSlotClick(slot.item);
        }
    }
}
