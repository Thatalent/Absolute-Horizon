using UnityEngine;
using System.Collections;

public interface BattleFactory {
	EnemyService createEnemyFactory ();
	BattleWave[] generateEnemyWaves ();
}
