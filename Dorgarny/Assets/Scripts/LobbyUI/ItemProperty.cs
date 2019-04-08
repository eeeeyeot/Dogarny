using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Equipment = 1,      //장비
    Consumption,    //소모
    etc             //기타
}

[System.Serializable]
public class ItemProperty {
    public string itemName;
    public Sprite sprite;
    public int price;
    public ItemType itemtype;
}
