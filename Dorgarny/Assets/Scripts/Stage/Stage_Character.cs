using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Character : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        StageManager.Instance.CheckStage(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        StageManager.Instance.CheckStage(other.name);
    }
}
