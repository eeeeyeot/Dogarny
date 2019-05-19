using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ActiveSkill", menuName = "Skills/ActiveSkill")]
public class ActiveSkill : Skill
{
	public float damageModifier;

	public Object skillEffect;

	public override void Use()
	{
		base.Use();

		GameObject instantObj = Instantiate(skillEffect, GameObject.FindWithTag("MainPlayer").transform) as GameObject;
		instantObj.SetActive(true);
	}
}
