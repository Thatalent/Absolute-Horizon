using UnityEngine;
using System.Collections;

public interface BattleFactory {
	BattleWave createBattleWave ();
	EnemyFactory createEnemyFactory ();
	void populateBattleWaves ();
}
