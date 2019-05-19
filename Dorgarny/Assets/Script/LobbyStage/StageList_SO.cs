using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StageList", menuName = "StageList")]
public class StageList_SO : ScriptableObject
{
    [System.Serializable]
    public class StageCombine {
        public string stagename;
        public int count;
        public int rewardGold;
        public int rewardExp;
    }
    
    public List<StageCombine> stageStarList;
    
}
