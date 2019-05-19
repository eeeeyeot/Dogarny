using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSwapManager : MonoBehaviour
{
	Transform[] players;
	private void Start()
	{
		players = GameObject.Find("Players").GetComponentsInChildren<Transform>();
	}

	public void OnChangeMainPlayer()
	{
		string ButtonName = EventSystem.current.currentSelectedGameObject.name;
		
		foreach(var p in players)
		{
			if(p.gameObject.name == ButtonName)
			{
				p.gameObject.tag = "MainPlayer";
			}
			else
			{
				p.gameObject.tag = "SubPlayer";
			}
		}
	}
}
