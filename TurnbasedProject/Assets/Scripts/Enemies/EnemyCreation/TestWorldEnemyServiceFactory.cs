using UnityEngine;
using System.Collections;
using System;

public class TestWorldEnemyServiceFactory : EnemyServiceFactory
{

    public EnemyClass[] createAndReturnEnemyMob(int numberOfEnemies)
    {
        return EnemySelection.getEnemyMob(numberOfEnemies);
    }

    public EnemyStrategy determineAttackPattern(Enemy currentEnemy)
    {

    }

}
