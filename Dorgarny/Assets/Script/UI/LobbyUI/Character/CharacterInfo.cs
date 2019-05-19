using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class CharacterInfo : MonoBehaviour
{
    CharacterManager characterManager;

    public Sprite defaultSprite;
    public Text cha_Level;
    public Image cha_Image;
    public Text class_txt;
    public Text maxHP_txt;
    public Text def_txt;
    public Text atk_txt;
    public Text ats_txt;

    public Slot equip_Weapon;
    public Slot equip_Armor;

    private void Start()
    {
        characterManager = CharacterManager.instance;
        SetInfo();
    }
  
    public void SetInfo()
    {
        int index = CharacterManager.instance.playerIndex;

        Debug.Log(index);
        cha_Level.text = characterManager.stats_List[index].level.GetValue().ToString();
        cha_Image.sprite = characterManager.stats_List[index].icon;
        class_txt.text = characterManager.stats_List[index].job;
        maxHP_txt.text = characterManager.stats_List[index].maxHealth.ToString();
        def_txt.text = characterManager.stats_List[index].def.GetValue().ToString();
        atk_txt.text = characterManager.stats_List[index].atk.GetValue().ToString();
        ats_txt.text = characterManager.stats_List[index].ats.GetValue().ToString();

        if (characterManager.stats_List[index].weapon != null) 
            equip_Weapon.icon.sprite = characterManager.stats_List[index].weapon.icon;
        else
        {
            equip_Weapon.icon.sprite = defaultSprite;
        }
        if (characterManager.stats_List[index].armor != null)
            equip_Armor.icon.sprite = characterManager.stats_List[index].armor.icon;
        else
        {
            equip_Armor.icon.sprite = defaultSprite;
        }
    }

    public void ClickInfo()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }

    public void SwapInfo(string index)
    {
        characterManager.playerIndex = int.Parse(index);
        SetInfo();
    }
}
