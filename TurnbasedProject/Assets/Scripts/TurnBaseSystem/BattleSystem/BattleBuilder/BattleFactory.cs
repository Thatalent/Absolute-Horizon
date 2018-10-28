using UnityEngine;
using System.Collections.Generic;

public interface BattleFactory {
	EnemyService createEnemyFactory ();
	Queue<BattleWave> generateEnemyWaves (int PlayerLevel);
}
