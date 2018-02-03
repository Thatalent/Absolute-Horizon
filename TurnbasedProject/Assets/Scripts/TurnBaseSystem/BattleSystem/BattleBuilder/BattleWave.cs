using UnityEngine;
using System.Collections;

public class BattleWave {

	public Enemy[] EnemyMob { get; set; }
    public Item [] ItemDrops { get; set; }
	public int EnemyExperience { get; set; }

	public void populateBattleWave (){
		EnemyGenerator eg = new EnemyGenerator ();
		eg.makeEnemy ();
	}
		

}
