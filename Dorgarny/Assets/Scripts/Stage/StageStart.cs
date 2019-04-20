using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : Buttons
{
    public override void ClickButton()
    {
        Debug.Log("Scene : " + StageManager.Instance.colliderName);
    }
    
}
