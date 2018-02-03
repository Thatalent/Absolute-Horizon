using UnityEngine;
using System.Collections;

public class TestWorldBattleFactoryService : BattleFactoryService
{
	public override BattleWave[] generateEnemyWaves (int PlayerLevel)
	{
		int NumberOfWaves = 1;
		if (PlayerLevel > 25) {
			NumberOfWaves = Random.Range (1, 2);
		}

		BattleWave[] newBattleWave = new BattleWave [NumberOfWaves];
		//create a TestWorldBattleWave
		for (int x = 0; x < NumberOfWaves; x++) {
			BattleWave bw = new BattleWave();
			bw.populateBattleWave ();
			newBattleWave [x] = bw;
		}
		return newBattleWave;
	}

	public override EnemyService createEnemyFactory ()
	{
		TestWorldEnemyServiceFactory newEnemyFactory = new TestWorldEnemyServiceFactory ();
		return newEnemyFactory;
	}
}