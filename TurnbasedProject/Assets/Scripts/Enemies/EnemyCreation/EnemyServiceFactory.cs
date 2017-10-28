using UnityEngine;
using System.Collections;
using System;

public abstract class EnemyServiceFactory : EnemyService {

    public abstract EnemyClass[] createAndReturnEnemyMob(int enemyNumber);
    public abstract EnemyStrategy determineAttackPattern(Enemy enemy);
    public abstract void addEnemyMoves(GameObject enemy);

    public enum EnemyStrategy { OFFENISVE, DEFENSIVE, LOWHEALTH, EASY, DANGEROUS, SUPPORTIVE }
    
    static public EnemyService newEnemyService(String world)
    {
        switch (world)
        {
            case "TestWorld": return new TestWorldEnemyServiceFactory();

            default: return new TestWorldEnemyServiceFactory();
        }
    }
}
