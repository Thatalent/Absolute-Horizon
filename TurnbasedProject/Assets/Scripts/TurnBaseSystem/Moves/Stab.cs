﻿using UnityEngine;
using System.Collections;

public class Stab : Moves {


	public Stab(){
		Name = "Stab";
		Player = BattleController.Player;
		Debug.Log (BattleController.Player.Strength);
		//Enemy = BattleController.Enemy;
		BrnRate = 0f;
		FrzRate = 0f;
		StnRate = 0f;
		PsnRate = 0f;
		DmgX = 1.0f;
		HitRate = 1.00f;
		DmgBoost = 2;
		EpUse = (int)(1/((float)(BattleController.Player.Strength+BattleController.Player.Skill)/100));
		MpUse = 0;
		SpUse = -0.2f;
        MoveCount = 3;	
	}
}
