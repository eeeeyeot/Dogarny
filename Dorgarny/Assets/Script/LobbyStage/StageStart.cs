using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageStart : Buttons
{
	public override void ClickButton()
	{
		Debug.Log("Scene : " + StageManager.Instance.colliderName);
		SceneManager.LoadScene(StageManager.Instance.colliderName);
	}

}
