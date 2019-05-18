using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInventoryUI : MonoBehaviour
{
    public Transform rootSlot; // slotroot
    public EquipmentManager equipment = EquipmentManager.instance;
    public GameObject equipinventoryUI;
    
    Inventory inventory;

    Slot[] slots;
    
    void Start()
    {
        Init();
    }

    public void Init()
    {
        inventory = Inventory.instance;
        slots = rootSlot.GetComponentsInChildren<Slot>();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //Equipment equipment = (Equipment)inventory.items[i];
            //if (equipment.equipSlot == category)
            //{
                if (i < inventory.items.Count)
                {
                    slots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    slots[i].ClearSlot();
                }
            //}
            slots[i].UpdateUI();
        }
    }


    public void EquipItem(Slot slot)
    {
        Equipment item = (Equipment)slot.item;
        item.Use(CharacterManager.instance.playerIndex);
        UpdateUI();
        CharacterManager.instance.UpdateUI();
    }



    public void Clickequipinventory(string type)
    {
        equipinventoryUI.SetActive(!equipinventoryUI.activeSelf);
        UpdateUI();
    }

    
}
