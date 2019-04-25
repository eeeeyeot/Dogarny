using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class EquipmentManager : MonoBehaviour
{
	#region Singleton
	public static EquipmentManager instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	#region 2D array in Inspector
	[System.Serializable]
	struct PlayersEquipment
	{
		public Equipment[] currentEquipment;
	}
	#endregion

	[SerializeField]
	PlayersEquipment[] playersEquipment;

	GameObject[] players;
	int mainPlayerIndex;

	private void Start()
	{
		Debug.Log("Start");
		int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		playersEquipment = new PlayersEquipment[Constants.PlayerNum];
		for (int i = 0; i < playersEquipment.Length; i++)
		{
			playersEquipment[i].currentEquipment = new Equipment[numSlots];
		}


		players = new GameObject[GameObject.Find("Players").transform.childCount];
		for(int i = 0; i < Constants.PlayerNum; i++)
		{
			players[i] = GameObject.Find("Players").transform.GetChild(i).gameObject;
			if(players[i].tag == "MainPlayer")
			{
				mainPlayerIndex = i;
			}
		}
	}



	//수정해야함 상시가 아닌 인벤토리에서 장착시로
	//캐릭터 스킬을 위한 기능
	private void Update()	
	{
		for(int i = 0; i < Constants.PlayerNum; i++)
		{
			if (players[i].tag == "MainPlayer")
			{
				mainPlayerIndex = i;
			}
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex] = (Equipment)Resources.Load("WeaponSheild");
		}

		if (playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex] != null)
		{
			Equipment equipment = playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex];
			PlayerSkillManager.instance.Equip(equipment);
		}
		else
		{
			PlayerSkillManager.instance.ClearSkills();
		}
	}
	
}