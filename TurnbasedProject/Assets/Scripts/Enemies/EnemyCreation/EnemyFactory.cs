using UnityEngine;
using System.Collections;
using System;

public abstract class EnemyFactory : EnemyService {

    public abstract EnemyStrategy determineAttackPattern(Enemy enemy);
    public abstract void addEnemyMoves(GameObject enemy);

    public enum EnemyStrategy { OFFENISVE, DEFENSIVE, LOWHEALTH, EASY, DANGEROUS, SUPPORTIVE }
    
    static public EnemyFactory newEnemyService(String world)
    {
        switch (world)
        {
            case "TestWorld": return new TestWorldEnemyServiceFactory();

            default: return new TestWorldEnemyServiceFactory();
        }
    }

	public EnemyClass[] createEnemyMob(int enemyNumber){
		
	}
}
