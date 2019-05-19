using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;


public class PlayerSkillManager : MonoBehaviour
{
	#region Singleton

	public static PlayerSkillManager instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	GameObject[] players;

	public Button[] BtnSkill = new Button[2];

	private void Start()
	{
		players = new GameObject[GameObject.Find("Players").transform.childCount];
		for(int i = 0; i < Constants.PlayerNum; i++)
		{
			players[i] = GameObject.Find("Players").transform.GetChild(i).gameObject;
			Debug.Log(players[i].name);
		}
	}




	public void Equip(Equipment newItem)
	{
		switch (newItem.equipSlot)
		{
			case EquipmentSlot.Armor:
				//Equip Armor
				break;
			case EquipmentSlot.Weapon:
				SetSkills((EquipmentWeapon)newItem);
				break;
		}
	}

	public void ClearSkills()
	{
		for (int i = 0; i < BtnSkill.Length; i++)
		{
			BtnSkill[i].image.sprite = null;
		}
	}

	void SetSkills(EquipmentWeapon newItem)
	{
		Debug.Log(newItem.name + " Equiped");
		for(int i = 0; i < BtnSkill.Length; i++)
		{
			BtnSkill[i].image.sprite = newItem.skill[i].icon;
		}
	}
}
