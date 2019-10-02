using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Text;
using System;

public class MissionManager : MonoBehaviour
{
    #region Singleton
    public static MissionManager instance = null;


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
    public MissionSO missionSO;
    private StringBuilder stringBuilder;

    private void Start()
    {
        stringBuilder = new StringBuilder("Mission");
        missionSO = (MissionSO)Resources.Load("ScriptableObject/Mission/MissionSO");
    }

    public void Reward(string title)
    {
        foreach (Mission mission in missionSO.missionList)
        {
            if (mission.missionid == title)
                mission.Reward();
        }

    }

    //Json 경로 C:\Users\HCM\AppData\LocalLow\DefaultCompany\new Dorgany\Json
    public void Save()
    {
        //C:\Users\HCM\AppData\LocalLow\DefaultCompany\new Dorgany\Json 경로에 Json 생성
        Debug.Log("Mission Save");
        JSONObject missionJson = new JSONObject();
        JSONObject missionID = new JSONObject();


        for (int i = 0; i < missionSO.missionList.Count; i++)
        {
            JSONArray data = new JSONArray();
            data.Add(missionSO.missionList[i].clearMission);
            data.Add(missionSO.missionList[i].missionid);
            data.Add(missionSO.missionList[i].missiondescription);
            data.Add(missionSO.missionList[i].needValue);
            data.Add(missionSO.missionList[i].currentValue);
            data.Add(missionSO.missionList[i].rewardGold);
            if (missionSO.missionList[i].rewardItem != null)
                data.Add(missionSO.missionList[i].rewardItem);
            else
                data.Add("Null");

            stringBuilder.Append(i);
            missionID.Add(stringBuilder.ToString(), data);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }

        missionJson.Add("Mission", missionID);

        string path = Application.persistentDataPath + "/Json/MissionData.json";
        File.WriteAllText(path, missionJson.ToString());
    }

    public void Load()
    {
        //C:\Users\HCM\AppData\LocalLow\DefaultCompany\new Dorgany\Json 경로 Json 읽어옴
        Debug.Log("Mission Load");
        string path = Application.persistentDataPath + "/Json/MissionData.json";
        string jsonString = File.ReadAllText(path);
        JSONObject missionJson = (JSONObject)JSON.Parse(jsonString);

        //Json값 가져오기
        for (int i = 0; i < missionJson["Mission"].Count; i++)
        {
            if (missionSO.missionList.Count < i + 1)
                missionSO.missionList.Add(new Mission());
            //Json값 ScriptableObject에 넣기
            missionSO.missionList[i].clearMission = (missionJson["Mission"][i][0] == "true");
            missionSO.missionList[i].missionid = missionJson["Mission"][i][1];
            missionSO.missionList[i].missiondescription = missionJson["Mission"][i][2];
            missionSO.missionList[i].needValue = missionJson["Mission"][i][3];
            missionSO.missionList[i].currentValue = missionJson["Mission"][i][4];
            missionSO.missionList[i].rewardGold = missionJson["Mission"][i][5];
            //아이템
            if (missionJson["Mission"][i][6] != "Null")
            {
                missionSO.missionList[i].rewardItem = missionJson["Mission"][i][6];
            }
            else
                missionSO.missionList[i].rewardItem = null;
        }

    }
}

