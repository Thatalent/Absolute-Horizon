using UnityEngine;
using System.Collections;

public class Attack {
	//TODO: refactor field name to totalDamage, attackerDamage, and defenderDefense (lol redundant)
	private int tDmg;

	private int pDmg;
	private int eDef;

	public Attack( int pDmg, int eDef) {


		this.pDmg = pDmg;
		this.eDef = eDef;


	}

	public int attacking (){

		tDmg = eDef-pDmg;

		return tDmg;
	}

	public bool effectRate (float rate){

		if (1.0f - rate < Random.value) {
			return true;
		}
		return false;
	}
	//TODO: refactor field name to TotalDamage, AttackerDamage, and DefenderDefense (lol redundant)
	private int TDmg{ get; set; }
	private int PDmg{ get; set; }
	private int EDef{ get; set; }


}
