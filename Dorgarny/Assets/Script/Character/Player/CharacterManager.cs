using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Util;

public class CharacterManager : MonoBehaviour
{
    #region Singleton
    public static CharacterManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion
    public Transform players;
    public List<CharacterStats> stats_List = new List<CharacterStats>();

    public CharacterInfo characterInfo;
    public int playerIndex = 0;

    void Start()
    {
        for (int i = 0; i < Constants.PlayerNum; i++)
        {
            stats_List.Add(players.GetChild(i).GetComponent<CharacterStats>());
        }
        //능력치 따로 지정해야함

        stats_List[0].job = "기사";
        stats_List[0].maxHealth = 300;
        stats_List[0].atk.baseValue = 10;
        stats_List[0].ats.baseValue = 1;
        stats_List[0].def.baseValue = 5;
        stats_List[0].currentXP.baseValue = 0;
        stats_List[0].level.baseValue = 1;
        stats_List[0].maxXp.baseValue = 1000;
        stats_List[0].weapon = null;
        stats_List[0].armor = null;

        stats_List[1].job = "궁수";
        stats_List[1].maxHealth = 150;
        stats_List[1].atk.baseValue = 20;
        stats_List[1].ats.baseValue = 1;
        stats_List[1].def.baseValue = 3;
        stats_List[1].currentXP.baseValue = 0;
        stats_List[1].level.baseValue = 1;
        stats_List[1].maxXp.baseValue = 1000;
        stats_List[1].weapon = null;
        stats_List[1].armor = null;

        stats_List[2].job = "성직자";
        stats_List[2].maxHealth = 200;
        stats_List[2].atk.baseValue = 5;
        stats_List[2].ats.baseValue = 1;
        stats_List[2].def.baseValue = 4;
        stats_List[2].currentXP.baseValue = 0;
        stats_List[2].level.baseValue = 1;
        stats_List[2].maxXp.baseValue = 1000;
        stats_List[2].weapon = null;
        stats_List[2].armor = null;
    }

    public void UpdateUI()
    {
        characterInfo.SetInfo();
    }
}
