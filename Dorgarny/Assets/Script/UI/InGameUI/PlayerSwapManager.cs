using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSwapManager : MonoBehaviour
{
	 public void ChangeToArcher()
	{
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
	}
}
