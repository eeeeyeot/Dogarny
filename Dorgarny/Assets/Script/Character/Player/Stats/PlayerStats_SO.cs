using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewStats", menuName = "Player/Stats", order = 1)]
public class PlayerStats_SO : ScriptableObject
{

	#region Field

	public Sprite icon;

    public bool setMenually = false;
    public bool saveDataOnClose = false;

    public float maxHealth = 0;
    public float currentHealth = 0;

    public float maxMana = 0;
    public float currentMana = 0;

    public float baseDamage = 0;
	private float currentDamage;

	public float CurrentDamage {
		get
		{
			if (weapon != null)
				return baseDamage + weapon.damageModifier;
			return baseDamage;
		}
		set{
			currentDamage = value;
		}
	}

	public float baseArmor = 0;
	public float CurrentArmor
	{
		get
		{
			if (armor != null)
				return baseArmor + armor.armorModifier;
			return baseArmor;
		}
	}

	public string job;
	public int level = 1;
	public float currentExp = 0;
	public float maxExp = 100;

    public float viewRange = 0;
    public float attackRange = 0;

	public EquipmentWeapon weapon;
	public EquipmentArmor armor;

	public ActiveSkill[] activeSkill = new ActiveSkill[2];
    #endregion


    #region Stat Increasers
    public void IncreaseHealth(float healthAmount)
    {
        if ((currentHealth + healthAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void IncreaseMana(float manaAmount)
    {
        if ((currentMana + manaAmount) > maxMana)
        {
            currentMana = maxMana;
        }
        else
        {
            currentMana += manaAmount;
        }
    }
    #endregion

    #region Stat Decreasers
    public void TakeDamage(float amount)
    {
        currentHealth -= amount - CurrentArmor;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeMana(float amount)
    {
        currentMana -= amount;

        if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }
    #endregion

    #region Death
    private void Death()
    {
        Debug.Log("<ENEMY DIE>");

    }
    #endregion

    #region SaveEnemyData
    public void saveEnemyData()
    {
        saveDataOnClose = true;
        EditorUtility.SetDirty(this);
    }
    #endregion
}
