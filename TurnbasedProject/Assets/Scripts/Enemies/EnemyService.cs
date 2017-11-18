﻿using UnityEngine;
using System.Collections;

public interface EnemyService {

    EnemyClass[] createAndReturnEnemyMob(int enemyNumber);

    EnemyServiceFactory.EnemyStrategy determineAttackPattern(Enemy enemy);

    void addEnemyMoves(GameObject enemy);
}