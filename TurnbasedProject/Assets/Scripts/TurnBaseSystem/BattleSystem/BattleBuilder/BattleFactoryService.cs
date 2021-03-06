﻿using UnityEngine;
using System.Collections.Generic;

public abstract class BattleFactoryService : BattleFactory {

	public abstract EnemyService createEnemyFactory ();
	public abstract Queue<BattleWave> generateEnemyWaves (int PlayerLevel);

	/// <summary>
	/// Returns a new instance of an implement child class for Battle Factory based on the player's location in the game universe.
	/// </summary>
	/// <param name="location"></param>
	/// <returns></returns>
	static public BattleFactory getNewBattleFactory(PlayerLocation location)
	{
		return new TestWorldBattleFactoryService();
	}
}
