using UnityEngine;
using System.Collections;

public interface EnemyService {

    EnemyClass[] createEnemyMob(int enemyNumber);

    EnemyFactory.EnemyStrategy determineAttackPattern(Enemy enemy);

    void addEnemyMoves(GameObject enemy);
}
