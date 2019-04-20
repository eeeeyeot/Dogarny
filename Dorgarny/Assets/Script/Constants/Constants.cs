﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
	public static class Constants{
		public static readonly int PlayerNum = 3;
		public static readonly int EquipmentWeaponIndex = 0;
	}

	public enum CharacterState
	{
		Idle = 0,
		Moving,
		Attack,
		Dead,
		Skill1,
		Skill2
	}

	public enum PlayerIndex
	{
		Player0,
		Player1,
		Player2
	}
}
