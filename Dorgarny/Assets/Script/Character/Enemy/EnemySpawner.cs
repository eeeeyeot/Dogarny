using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    public string enemyType;
    public Transform point;
}

public class EnemySpawner : MonoBehaviour
{
   
    public List<SpawnPoint> spawnPoints;
    private EnemyPooler enemyPooler;
    private bool isEntered = false;

    private void Start()
    {
        enemyPooler = EnemyPooler.Instance;
    }

    //Trigger => 몬스터 SpawnPoint에 스폰
    private void OnTriggerEnter(Collider other)
    {
        if (!isEntered)
        {
            if (other.gameObject.tag == "MainPlayer")
            {
                enemyPooler.GetPooledObject(spawnPoints);
                isEntered = true;
            }
        }
    }
}
