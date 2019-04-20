using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CharacterManager : Singleton<CharacterManager>
{
    public Transform chaTransform;
    private Dictionary<string, CharacterInfo> dictcharacterInfo;
    public void Start()
    {
        Init();
    }
    public void Init()
    {
        TextAsset resource = Resources.Load("Json/CharacterInfo") as TextAsset;
        JSONNode root = JSON.Parse(resource.text);
        
        InitCharacterInfo(root);

        Debug.Log("init complete CharacterManager");

        
    }
    
    public void InitCharacterInfo(JSONNode root)
    {
        CharacterInfo chaInfo = new CharacterInfo();
        JSONNode chafos = root["character"];
        for (int i = 0; i < chafos.Count; i++)
        {
            JSONNode jsonInfo = chafos[i];
            
            chaInfo.id = jsonInfo["id"];
            chaInfo.level = jsonInfo["name"];
            chaInfo.attack = jsonInfo["description"];
            chaInfo.attackSpeed = jsonInfo["name"];
            chaInfo.defense = jsonInfo["name"];
            chaInfo.maxHealth = jsonInfo["name"];
            //ItemInfo weapon = ItemManager.Instance.Find(jsonInfo["equipWeapon"]);
            //chaInfo.equipWeapon.id = weapon.id;
            //chaInfo.equipWeapon.name = weapon.name;
            //ItemInfo sheild = ItemManager.Instance.Find(jsonInfo["equipSheild"]);
            //chaInfo.equipSheild.id = sheild.id;
            //chaInfo.equipSheild.name = sheild.name;
        }

        //dictcharacterInfo.Add(chaInfo.id, chaInfo);
    }

    public CharacterInfo Find(string id)
    {
        return dictcharacterInfo[id];
    }
}
