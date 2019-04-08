using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public ItemProperty item;
    public int itemCount = 0;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Text text_Count;
    public GameObject go_Countimage;

    public void SetItem(ItemProperty item, int _count = 1)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;
            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;
            gameObject.name = item.itemName;
            image.sprite = item.sprite;
            image.color = new Color(255, 255, 255, 1);
            if (go_Countimage != null && text_Count != null)
                if (item.itemtype != ItemType.Equipment)
                {
                    go_Countimage.SetActive(true);
                    text_Count.text = itemCount.ToString();
                }
        }
    }
}
