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

    int starCount;
    List<Image> starList = new List<Image>();
    Transform WinUI;
    Transform LoseUI;

	public bool IsPlayerDied { get; set; }


	#region Singleton
	public static EndUI instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of EndUI");
		}
		instance = this;
	}
	#endregion

	void Start()
    {
        starCount = 0;
        for (int i = 0; i < stars.childCount; i++)
        {
            starList.Add(stars.GetChild(i).GetComponent<Image>());
        }
        WinUI = this.transform.GetChild(0).GetComponent<Transform>();
        LoseUI = this.transform.GetChild(1).GetComponent<Transform>();
    }

    public void WinUIOn()
    {
        CheckQuest();
        DrawWinUI();
        WinUI.gameObject.SetActive(true);
    }

    public void LoseUIOn()
    {
        LoseUI.gameObject.SetActive(true);
    }

    public void CheckQuest()
    {
        for (int i = 0; i < QuestInfoSO.questList.Count; i++)
        {
            if (QuestInfoSO.questList[i].stagename == SceneManager.GetActiveScene().name)
            {
                // 아무 캐릭터가 안죽었을때
                if (!IsPlayerDied)
                {
                    QuestInfoSO.questList[i].quest[0].complete = true;
                    starCount++;
                }
                // 포션을 사용안한 경우
                if (GameManager.Instance.potionUseCount == 0)
                {
                    QuestInfoSO.questList[i].quest[1].complete = true;
                    starCount++;
                }
                // 시간내에 클리어
                if (GameManager.Instance.time.GetTimeSecond() <= 150)
                {
                    QuestInfoSO.questList[i].quest[2].complete = true;
                    starCount++;
                }

				Debug.Log(starCount);
            }
        }
    }

    void DrawWinUI()
    {
        int stageStar = 0;
        for (int i = 0; i < starCount; i++)
            starList[i].sprite = fillstar;

        for (int i = 0; i < QuestInfoSO.questList.Count; i++)
        {
            if (QuestInfoSO.questList[i].stagename == SceneManager.GetActiveScene().name)
            {
                for (int j = 0; j < QuestInfoSO.questList[i].quest.Length; j++)
                {
                    missiontxtList[j].text = QuestInfoSO.questList[i].quest[j].quest;
                    if (QuestInfoSO.questList[i].quest[j].complete == true)
                        stageStar++;
                }
            }
        }
        for (int i = 0; i < StageList_SO.stageStarList.Count; i++)
        {
            if (StageList_SO.stageStarList[i].stagename == SceneManager.GetActiveScene().name)
            {
                rewardtxtList[0].text = StageList_SO.stageStarList[i].rewardGold.ToString();
                rewardtxtList[1].text = StageList_SO.stageStarList[i].rewardExp.ToString();
                if (stageStar > StageList_SO.stageStarList[i].count)
                    StageList_SO.stageStarList[i].count = stageStar;
            }
        }
    }

    private void Update()
    {
      
    }
}
