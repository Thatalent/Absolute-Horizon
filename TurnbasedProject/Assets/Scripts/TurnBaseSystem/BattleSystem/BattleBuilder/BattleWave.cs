using UnityEngine;
using System.Collections;

public class BattleWave {

	public GameObject[] EnemyMob { get; set; }
    public Item [] ItemDrops { get; set; }
	public int EnemyExperience { get; set; }

	public EnemyService enemyFactory { get; set; }

	public void populateBattleWave (){
		EnemyGenerator eg = new EnemyGenerator ();
		EnemyMob = eg.makeEnemy (enemyFactory);
	}
		

}
