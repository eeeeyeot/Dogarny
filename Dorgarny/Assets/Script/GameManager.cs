using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //스테이지 미션조건 달성시
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < StageManager.instance.stageSO.stageStarList.Count; i++)
            {
                if (SceneManager.GetActiveScene().name == StageManager.instance.stageSO.stageStarList[i].stagename)
                    StageManager.instance.stageSO.stageStarList[i].count++;
            }
        }
    }
}
