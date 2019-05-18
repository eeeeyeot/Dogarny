using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text timeText;
    public int potionUseCount = 0;
    public class TimerMS
    {
        public float m = 0;
        public float s = 0;
        public string GetTimeString()
        {
            if (s >= 60)
            {
                m++;
                s = 0;
            }
            if (s < 9.5f)
            {
                return m.ToString() + " : 0" + s.ToString("N0");
            }
            return m.ToString() + " : " + s.ToString("N0");
        }
        public float GetTimeSecond()
        {
            return (m * 60) + s;
        }
    }

    public TimerMS time = new TimerMS();

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time.s += Time.deltaTime;

        timeText.text = time.GetTimeString();
        ////스테이지 미션조건 달성시
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    for (int i = 0; i < StageManager.instance.stageSO.stageStarList.Count; i++)
        //    {
        //        if (SceneManager.GetActiveScene().name == StageManager.instance.stageSO.stageStarList[i].stagename)
        //            StageManager.instance.stageSO.stageStarList[i].count++;
        //    }
        //}
    }
}
