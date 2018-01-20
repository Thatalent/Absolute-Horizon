using UnityEngine;
using System.Collections;

public class TestWorldBattleFactoryService : BattleFactoryService {

	public BattleWave generateBattleWaves()
    {
        return new BattleWave();
		//insert enemyfactory creation
    }
}
