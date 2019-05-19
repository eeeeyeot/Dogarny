using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Sprite icon;
    public string job;
    public Stat level;
    public Stat currentXP;
    public Stat maxXp;

    public Stat atk;
    public Stat ats;
    public Stat def;

    public EquipmentWeapon weapon = null;
    public EquipmentArmor armor = null;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void Die()
    {

    }
    
}
