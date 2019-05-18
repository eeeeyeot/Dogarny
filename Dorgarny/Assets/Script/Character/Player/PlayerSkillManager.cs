﻿using System.Collections;
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

	delegate void SkillDelegate();

	public Button[] BtnSkill = new Button[2];
	public Sprite transparent_Spr;

	private void Start()
	{
		players = new GameObject[GameObject.Find("Players").transform.childCount];
		for (int i = 0; i < Constants.PlayerNum; i++)
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
			BtnSkill[i].image.sprite = transparent_Spr;
			BtnSkill[i].onClick.RemoveAllListeners();
		}
	}

	void SetSkills(EquipmentWeapon newItem)
	{
		for (int i = 0; i < BtnSkill.Length; i++)
		{
			BtnSkill[i].onClick.RemoveAllListeners();
			Debug.Log("Skill Added");
			BtnSkill[i].image.sprite = newItem.skill[i].icon;
			SkillDelegate skillDel = new SkillDelegate(newItem.skill[i].Use);

			BtnSkill[i].onClick.AddListener(
				() =>
				{
					skillDel();
				});
		}

	}
}
