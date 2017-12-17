using UnityEngine;
using System.Collections;

public class TestWorldBattleFactoryService : BattleFactoryService {

    public override BattleWave[] generateEnemyWaves()
    {
        BattleWave[] newBattleWaves = { new BattleWave()};
        return newBattleWaves;
    }
}
