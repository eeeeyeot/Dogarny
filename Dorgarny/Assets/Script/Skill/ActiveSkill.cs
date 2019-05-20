using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

[CreateAssetMenu(fileName = "New ActiveSkill", menuName = "Skills/ActiveSkill")]
public class ActiveSkill : Skill
{
	public float damageModifier;
	public SkillIndex skillIndex;
	public Object skillEffect;
	private GameObject mainP;
	public void Use(SkillAnimation skillAnimation)
	{
		base.Use();
		skillAnimation();
		mainP = GameObject.FindWithTag("MainPlayer");
		GameObject gameObject = GameObject.Find(mainP.name + "Skill" + (int)skillIndex);
		if (gameObject == null)
			Debug.Log("Cant Find Skill");
		else
			gameObject.GetComponentInChildren<ParticleSystem>().Play();
	}
}

public enum SkillIndex{
	First = 1,
	Second
}