using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public ItemInfo item;
    public int itemCount = 0;
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.Text text_Count;
    public UnityEngine.UI.Text text_Price = null;
    public GameObject go_Countimage;

    public void SetItem(ItemInfo item, int _count = 1)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;
            gameObject.name = "Empty";
        }
        else
        {

            if (item.price != 0 && text_Price != null)
                text_Price.text = item.price.ToString();
            image.enabled = true;
            gameObject.name = item.name;
            image.sprite = item.sprite;
            image.color = new Color(255, 255, 255, 1);
            if (go_Countimage != null && text_Count != null)
                if (item.category == ItemInfo.Category.Potion)
                {
                    go_Countimage.SetActive(true);
                    text_Count.text = itemCount.ToString();
                }
        }
    }
}
