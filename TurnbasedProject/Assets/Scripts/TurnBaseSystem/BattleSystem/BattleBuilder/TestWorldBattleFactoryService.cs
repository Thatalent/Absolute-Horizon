using UnityEngine;
using System.Collections.Generic;

public class TestWorldBattleFactoryService : BattleFactoryService
{
	public override Queue<BattleWave> generateEnemyWaves (int PlayerLevel)
	{
		int NumberOfWaves = 1;
		if (PlayerLevel > 25) {
			NumberOfWaves = Random.Range (1, 2);
		}

		Queue<BattleWave> newBattleWave = new Queue<BattleWave>();
		EnemyService factory = this.createEnemyFactory();
		//create a TestWorldBattleWave
		for (int x = 0; x < NumberOfWaves; x++) {
			BattleWave bw = new BattleWave();
			// bw.populateBattleWave();
			bw.enemyFactory = factory;
			newBattleWave.Enqueue(bw);
		}
		return newBattleWave;
	}

	public override EnemyService createEnemyFactory ()
	{
		TestWorldEnemyServiceFactory newEnemyFactory = new TestWorldEnemyServiceFactory ();
		return (EnemyService)newEnemyFactory;
	}
}