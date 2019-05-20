using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerStats_SO PlayerDefinition;

    #region Initalizations
    void Start()
    {
        if (!PlayerDefinition.setMenually)
        {
            PlayerDefinition.maxHealth = 100;
            PlayerDefinition.currentHealth = 50;

            PlayerDefinition.maxMana = 100;
            PlayerDefinition.currentMana = 50;

            PlayerDefinition.baseDamage = 20;
            PlayerDefinition.CurrentDamage = 20;
        }
		else
		{
			PlayerDefinition.currentHealth = PlayerDefinition.maxHealth;
			PlayerDefinition.currentMana = PlayerDefinition.maxMana;
		}

		//switch(gameObject.name){
		//	case "Warrior":
		//		PlayerDefinition.activeSkill = ((EquipmentWeapon)Resources.Load("ScriptableObject/Items/Warrior/WeaponSheild")).skill;
		//		break;
		//	case "Archer":
		//		PlayerDefinition.activeSkill = ((EquipmentWeapon)Resources.Load("ScriptableObject/Items/Archer/WeaponBow")).skill;
		//		break;
		//	case "Wizard":
		//		PlayerDefinition.activeSkill = ((EquipmentWeapon)Resources.Load("ScriptableObject/Items/Wizard/WeaponStaff")).skill;
		//		break;
		//}
		//Debug.Log(PlayerDefinition.activeSkill[0].icon.name);
		//Debug.Log(PlayerDefinition.activeSkill[1].icon.name);
	}
    #endregion

    #region Stat Increasers
    public void IncreaseHealth(float healthAmount)
    {
        PlayerDefinition.IncreaseHealth(healthAmount);
    }

    public void IncreaseMana(float manaAmount)
    {
        PlayerDefinition.IncreaseMana(manaAmount);
    }
    #endregion

    #region Stat Decreasers
    public void TakeDamage(float amount)
    {
        PlayerDefinition.TakeDamage(amount);
    }

    public void TakeMana(float amount)
    {
        PlayerDefinition.TakeMana(amount);
    }
    #endregion

    #region SaveEnemyData
    public void saveEnemyData()
    {
        //'$'면 상태 저장
        if (Input.GetKeyDown(KeyCode.Dollar))
        {
            PlayerDefinition.saveEnemyData();
        }
    }
    #endregion

    #region Get 
    public float GetHealth()
    {
        return PlayerDefinition.currentHealth;
    }

	public float GetMaxHealth(){
		return PlayerDefinition.maxHealth;
	}

    public float GetMana()
    {
        return PlayerDefinition.currentMana;
    }

    public float GetDamage()
    {
        return PlayerDefinition.CurrentDamage;
    }

    public float GetViewRange()
    {
        return PlayerDefinition.viewRange;
    }

    public float GetAttackRange()
    {
        return PlayerDefinition.attackRange;
    }
    #endregion
}
