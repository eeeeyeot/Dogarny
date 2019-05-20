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

	delegate void SkillDelegate(SkillAnimation animation);

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

		//ActiveSkill[] skills = GameObject.FindWithTag("MainPlayer").GetComponent<PlayerStats>().PlayerDefinition.activeSkill;
		//SetSkills(skills);
		//SetSkills(((EquipmentWeapon)Resources.Load("ScriptableObject/Items/Warrior/WeaponSheild")).skill);
	}

	private void Update()
	{
		SetSkills(GameObject.FindWithTag("MainPlayer").GetComponent<PlayerStats>().PlayerDefinition.activeSkill);
	}

	public void Equip(Equipment newItem)
	{
		switch (newItem.equipSlot)
		{
			case EquipmentSlot.Armor:
				//Equip Armor
				break;
			case EquipmentSlot.Weapon:
				SetSkills(((EquipmentWeapon)newItem).skill);
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

	void SetSkills(ActiveSkill[] newSkill)
	{
		if(newSkill[0] == null)
		{
			return;
		}

		for (int i = 0; i < BtnSkill.Length; i++)
		{
			BtnSkill[i].onClick.RemoveAllListeners();
			BtnSkill[i].image.sprite = newSkill[i].icon;
			SkillDelegate skillDel = new SkillDelegate(newSkill[i].Use);
			SkillAnimation skillAnim = new SkillAnimation(ActiveSkill);
			BtnSkill[i].onClick.AddListener(
				() =>
				{
					skillDel(skillAnim);
				});
		}
	}

	void ActiveSkill()
	{
		GameObject.FindWithTag("MainPlayer").GetComponent<FSMPlayer>().anim.SetTrigger("Skill");
	}
}
