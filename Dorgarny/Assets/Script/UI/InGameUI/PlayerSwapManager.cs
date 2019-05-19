using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSwapManager : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
	 public void ChangeToArcher()
	{
=======
	 public void ChangeToArcher()
	{
>>>>>>> parent of 768d38e... 2019-05-19
=======
	 public void ChangeToArcher()
	{
>>>>>>> parent of 768d38e... 2019-05-19
		GameObject.Find("Archer").tag = "MainPlayer";
		GameObject.Find("Warrior").tag = "SubPlayer";
		GameObject.Find("Wizard").tag = "SubPlayer";
	}
	public void ChangeToWarrior()
	{
		GameObject.Find("Warrior").tag = "MainPlayer";
		GameObject.Find("Archer").tag = "SubPlayer";
		GameObject.Find("Wizard").tag = "SubPlayer";
	}
	public void ChangeToWizard()
	{
		GameObject.Find("Wizard").tag = "MainPlayer";
		GameObject.Find("Warrior").tag = "SubPlayer";
		GameObject.Find("Archer").tag = "SubPlayer";
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 768d38e... 2019-05-19
=======
>>>>>>> parent of 768d38e... 2019-05-19
=======
>>>>>>> parent of 768d38e... 2019-05-19
	}
}
