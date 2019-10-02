

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using Util;
using System.IO;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory");
        }

        instance = this;

    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback = null;

    public int space = 80;                      //가방 공간

    //public Dictionary<Item, int> items_count = new Dictionary<Item, int>();
    public List<Item> items = new List<Item>();

    public bool Add(Item item_)
    {
        if (item_ == null)
            return false;

        if (!item_.isDefaultItem)
        {
            //겹칠수 있는 아이템인지 확인
            if (item_.category == Category.Consume)
            {
                //인벤토리가 비었는지, 인벤토리가 꽉찼는지 검사
                if (items.Count > 0 && InventoryCheck())
                {
                    //겹칠게 있나 확인 있으면 아이템값 증가, 없으면 생성
                    if (!CheckItemCount(item_))
                    {
                        //새로운 아이템을 추가
                        Item tempItem = ScriptableObject.CreateInstance<Item>();
                        tempItem.category = item_.category;
                        tempItem.icon = item_.icon;
                        tempItem.name = item_.name;
                        tempItem.price = item_.price;
                        tempItem.isDefaultItem = item_.isDefaultItem;

                        tempItem.count++;
                        items.Add(tempItem);
                    }
                }
                else
                {
                    //새로운 아이템을 추가할 때 기존 ScriptableObject와 겹침 해결
                    ConsumePotion tempItem = ScriptableObject.CreateInstance<ConsumePotion>();

                    tempItem.category = item_.category;
                    tempItem.icon = item_.icon;
                    tempItem.name = item_.name;
                    tempItem.price = item_.price;
                    tempItem.isDefaultItem = item_.isDefaultItem;

                    tempItem.amount = ((ConsumePotion)item_).amount;
                    
                    tempItem.count = 1;
                    items.Add(tempItem);
                }
                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
            }
            else
            {
                if (InventoryCheck())
                {
                    //items.Add(item_);
                    Equipment tempItem = ScriptableObject.CreateInstance<Equipment>();

                    tempItem.category = item_.category;
                    tempItem.icon = item_.icon;
                    tempItem.name = item_.name;
                    tempItem.price = item_.price;
                    tempItem.isDefaultItem = item_.isDefaultItem;

                    tempItem.equipSlot = ((Equipment)item_).equipSlot;
                    tempItem.armorModifier = ((Equipment)item_).armorModifier;
                    tempItem.damageModifier = ((Equipment)item_).damageModifier;

                    tempItem.count = 1;
                    items.Add(tempItem);
                }
                else
                {
                    Debug.Log("인벤토리가 꽉참");
                }

                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    // 아이템 강제 추가
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Add((Equipment)Resources.Load("ScriptableObject/Items/Warrior/WeaponSheild"));
        if (Input.GetKeyDown(KeyCode.L))
            Add((Equipment)Resources.Load("ScriptableObject/Items/Wizard/WeaponStaff"));
        if (Input.GetKeyDown(KeyCode.S))
            Save();
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void Save()
    {
        Debug.Log("Item Save");
        JSONObject itemJson = new JSONObject();
        JSONObject inventory = new JSONObject();

        for(int i = 0; i < items.Count; i++)
        {
            JSONArray data = new JSONArray();
            data.Add(items[i].name);
            data.Add(items[i].count);
            inventory.Add(i.ToString(), data);
        }

        itemJson.Add("Inventory", inventory);

        string path = Application.persistentDataPath + "/Json/Inventory.json";
        File.WriteAllText(path, itemJson.ToString());
    }

    public void Load(int level)
    {
        Debug.Log("Item Load");
    }

    private bool InventoryCheck()
    {
        if (items.Count >= space)
            return false;
        else
            return true;
    }

    private bool CheckItemCount(Item item_)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == item_.name)
            {
                if (items[i].count < 99)
                {
                    items[i].count++;
                    return true;
                }
            }
        }
        return false;
    }
}
