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
            PlayerDefinition.currentDamage = 20;
        }
		else
		{
			PlayerDefinition.currentHealth = PlayerDefinition.maxHealth;
			PlayerDefinition.currentMana = PlayerDefinition.maxMana;
		}
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
        return PlayerDefinition.currentDamage;
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
