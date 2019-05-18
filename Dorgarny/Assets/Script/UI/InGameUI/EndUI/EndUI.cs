using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    public Sprite fillstar;
    public QuestInfo QuestInfoSO;
    public StageList_SO StageList_SO;
    public Transform stars;
    public List<Text> missiontxtList;
    public List<Text> rewardtxtList;

    int starCount = 0;
    List<Image> starList = new List<Image>();
    Transform WinUI;
    Transform LoseUI;

    void Start()
    {
        for (int i = 0; i < stars.childCount; i++)
        {
            starList.Add(stars.GetChild(i).GetComponent<Image>());
        }
        WinUI = this.transform.GetChild(0).GetComponent<Transform>();
        LoseUI = this.transform.GetChild(1).GetComponent<Transform>();

        Debug.Log(WinUI.gameObject.name);
        Debug.Log(LoseUI.gameObject.name);
    }

    public void WinUIOn()
    {
        DrawWinUI();
        WinUI.gameObject.SetActive(true);
    }

    public void LoseUIOn()
    {
        LoseUI.gameObject.SetActive(true);
    }

    void DrawWinUI()
    {
        for (int i = 0; i < starCount; i++)
            starList[i].sprite = fillstar;

        for (int i = 0; i < QuestInfoSO.questList.Count; i++)
        {
            if (QuestInfoSO.questList[i].stagename == SceneManager.GetActiveScene().name)
            {
                for (int j = 0; j < QuestInfoSO.questList[i].quest.Length; j++)
                {
                    missiontxtList[j].text = QuestInfoSO.questList[i].quest[j].quest;
                }
            }
        }

        for(int i = 0; i< StageList_SO.stageStarList.Count; i++)
        {
            if (StageList_SO.stageStarList[i].stagename == SceneManager.GetActiveScene().name)
            {
                rewardtxtList[0].text = StageList_SO.stageStarList[i].rewardGold.ToString();
                rewardtxtList[1].text = StageList_SO.stageStarList[i].rewardExp.ToString();
            }
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            WinUIOn();
        if (Input.GetKeyDown(KeyCode.W))
            LoseUIOn();
    }
}
