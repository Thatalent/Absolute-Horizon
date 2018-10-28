using UnityEngine;
using System.Collections;

public class Stab : Moves, AttackMove {


	public Stab(){
		Name = "Stab";
		//Enemy = BattleController.Enemy;
		BrnRate = 0f;
		FrzRate = 0f;
		StnRate = 0f;
		PsnRate = 0f;
		DmgX = 1.0f;
		HitRate = 1.00f;
		DmgBoost = 2;
		MpUse = 0;
		SpUse = -0.2f;
        MoveCount = 3;	
	}

	/// <summary>
    /// Hides the original EpUse so a unique value can be obtain based on the player's current stats.
    /// </summary>
    /// <returns></returns>
    public new int EpUse
    {
        get
        {
            return (int)(1 / ((float)(Player.Strength + Player.Skill) / 100));
        }
    }
}
