using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : Singleton<GoldManager>
{
    public Text goldtext;
    private int gold = 99999;

    public int Gold { get { return gold; } set { gold += value; SetText(); } }

    public void Start()
    {
        SetText();
    }

    public void SetText()
    {
        goldtext.text = gold.ToString();
    }
         
}
