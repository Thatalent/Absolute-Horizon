using UnityEngine;
using System.Collections;
using System;

public class TestWorldEnemyServiceFactory : EnemyServiceFactory
{
    public override void addEnemyMoves(GameObject enemy)
    {
        
    }

    public override EnemyClass[] createAndReturnEnemyMob(int numberOfEnemies)
    {
        return EnemySelection.getWorld1EnemyMob(numberOfEnemies);
    }

    public override EnemyStrategy determineAttackPattern(Enemy currentEnemy)
    {
        return EnemyStrategy.EASY;
    }

  
}
