using UnityEngine;
using System.Collections;

public class TestWorldBattleFactoryService : BattleFactoryService
{
	public override BattleWave[] generateEnemyWaves ()
	{
		//create a TestWorldBattleWave
		BattleWave newBattleWave = new BattleWave ();
		return newBattleWave;
	}

	public override EnemyService createEnemyFactory ()
	{
		TestWorldEnemyServiceFactory newEnemyFactory = new TestWorldEnemyServiceFactory ();
		return newEnemyFactory;
	}
}