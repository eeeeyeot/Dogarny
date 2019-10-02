using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission : Observer
{
    public bool clearMission = false;
    public string missionid;
    public string missiondescription;
    public int needValue;
    public int currentValue;
    public int rewardGold;
    public string rewardItem;
    public bool getReward = false;
    

    public override void OnNotify(string id, int value)
    {
        if (missionid == id && !clearMission) {
            currentValue += value;
            if (needValue <= currentValue)
            {
                clearMission = true;
            }
        }

        
    }

    public void Reward()
    {
        GoldManager.instance.Gold += rewardGold;
        getReward = true;
        if (rewardItem != "Null")
        {
            Inventory.instance.Add(Resources.Load("ScriptableObject/Items/Reward/" + rewardItem) as Item);
        }
    }
}
