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

    //public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    //public OnEquipmentChanged onEquipmentChanged;

	[SerializeField]
	//PlayersEquipment[] playersEquipment;

	//GameObject[] players;
	//int mainPlayerIndex;

    Inventory inventory;
    CharacterManager characterManager;
	private void Start()
	{
        inventory = Inventory.instance;
        characterManager = CharacterManager.instance;

        Debug.Log("Start");
		//int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		//playersEquipment = new PlayersEquipment[Constants.PlayerNum];
		//for (int i = 0; i < playersEquipment.Length; i++)
		//{
		//	playersEquipment[i].currentEquipment = new Equipment[numSlots];
		//}
        
        //players = new GameObject[GameObject.Find("Players").transform.childCount];
        //for(int i = 0; i < Constants.PlayerNum; i++)
        //{
        //	players[i] = GameObject.Find("Players").transform.GetChild(i).gameObject;
        //	if(players[i].tag == "MainPlayer")
        //	{
        //		mainPlayerIndex = i;
        //	}
        //}
    }



	//수정해야함 상시가 아닌 인벤토리에서 장착시로
	//캐릭터 스킬을 위한 기능
<<<<<<< HEAD
	public void Equip(Equipment newItem, int playerIndex = 0)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;

        switch (slotIndex) {
            case 0:
                oldItem = characterManager.stats_List[playerIndex].weapon;
                inventory.Add(oldItem);
                OnEquipmentChanged(playerIndex, newItem, oldItem);
                characterManager.stats_List[playerIndex].weapon = (EquipmentWeapon)newItem;
                break;
            case 1:
                oldItem = characterManager.stats_List[playerIndex].armor;
                inventory.Add(oldItem);
                OnEquipmentChanged(playerIndex, newItem, oldItem);
                characterManager.stats_List[playerIndex].armor = (EquipmentArmor)newItem;
                break;
        }

        //for (int i = 0; i < Constants.PlayerNum; i++)
        //{
        //    if (players[i].tag == "MainPlayer")
        //    {
        //        mainPlayerIndex = i;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex] = (Equipment)Resources.Load("WeaponSheild");
        //}

        //if (playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex] != null)
        //{
        //    Equipment equipment = playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex];
        //    PlayerSkillManager.instance.Equip(equipment);
        //}
        //else
        //{
        //    PlayerSkillManager.instance.ClearSkills();
        //}
    }
=======
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
			playersEquipment[mainPlayerIndex].currentEquipment[Constants.EquipmentWeaponIndex] = 
				(Equipment)Resources.Load("ScriptableObject/Items/Wizard/WeaponStaff");
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
>>>>>>> parent of 768d38e... 2019-05-19
	
    public void Unequip (int playerIndex, int slotIndex)
    {
        switch (slotIndex)
        {
            case 0:
                if (characterManager.stats_List[playerIndex].weapon != null)
                {
                    Equipment oldItem = characterManager.stats_List[playerIndex].weapon;
                    inventory.Add(oldItem);

                    characterManager.stats_List[playerIndex].weapon = null;
                    
                    OnEquipmentChanged(playerIndex, null, oldItem);
                }
                    break;
            case 1:
                if (characterManager.stats_List[playerIndex].armor != null)
                {
                    Equipment oldItem = characterManager.stats_List[playerIndex].armor;
                    inventory.Add(oldItem);

                    characterManager.stats_List[playerIndex].weapon = null;

                    OnEquipmentChanged(playerIndex, null, oldItem);
                }
                break;
        }
       
        
    }

    public void UnequipAll(int playerIndex)
    {
        for(int i = 0; i < Constants.EquipmentItemSlotIndex; i++)
        {
            Unequip(playerIndex, i);
        }
    }

    void OnEquipmentChanged(int playerIndex, Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            characterManager.stats_List[playerIndex].def.AddModifier(newItem.armorModifier);
            characterManager.stats_List[playerIndex].atk.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            characterManager.stats_List[playerIndex].def.RemoveModifier(oldItem.armorModifier);
            characterManager.stats_List[playerIndex].atk.RemoveModifier(oldItem.damageModifier);
        }
    }
}