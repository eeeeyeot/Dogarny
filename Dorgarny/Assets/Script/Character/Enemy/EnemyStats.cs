using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyStats_SO EnemyDefinition = new EnemyStats_SO();

    #region Initalizations
    void Start()
    {
        if (!EnemyDefinition.setMenually)
        {
            EnemyDefinition.maxHealth = 100;
            EnemyDefinition.currentHealth = 50;

            EnemyDefinition.maxMana = 100;
            EnemyDefinition.currentMana = 50;

            EnemyDefinition.baseDamage = 20;
        }
        else
        {
            EnemyDefinition.currentHealth = EnemyDefinition.maxHealth;
            EnemyDefinition.currentMana = 0;
        }
    }
    #endregion

    #region Stat Increasers
    public void IncreaseHealth(float healthAmount)
    {
        EnemyDefinition.IncreaseHealth(healthAmount);
    }

    public void IncreaseMana(float manaAmount)
    {
        EnemyDefinition.IncreaseMana(manaAmount);
    }
    #endregion

    #region Stat Decreasers
    public void TakeDamage(float amount)
    {
        EnemyDefinition.TakeDamage(amount);
        GetComponent<EnemyController>().Anim.SetTrigger("Damaged");
    }

    public void TakeMana(float amount)
    {
        EnemyDefinition.TakeMana(amount);
    }
    #endregion
    
    #region SaveEnemyData
    public void saveEnemyData()
    {
        //'$'면 상태 저장
        if(Input.GetKeyDown(KeyCode.Dollar))
        {
            EnemyDefinition.saveEnemyData();
        }
    }
    #endregion

    #region Get 
    public float GetHealth()
    {
        return EnemyDefinition.currentHealth;
    }

    public float GetMana()
    {
        return EnemyDefinition.currentMana;
    }

    public float GetMaxMana()
    {
        return EnemyDefinition.maxMana;
    }

    public float GetDamage()
    {
        return EnemyDefinition.baseDamage;
    }

    public float GetManaIncrement()
    {
        return EnemyDefinition.manaIncrement;
    }

    public float GetViewRange()
    {
        return EnemyDefinition.viewRange;
    }

    public float GetAttackRange()
    {
        return EnemyDefinition.attackRange;
    }
    #endregion

    public void SetCurrentMana(float amount)
    {
        EnemyDefinition.currentMana = amount;
    }
}
