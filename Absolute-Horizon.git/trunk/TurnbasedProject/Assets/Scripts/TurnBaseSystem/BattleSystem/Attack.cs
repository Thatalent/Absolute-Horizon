using UnityEngine;
using System.Collections;

public class Attack {

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

	private int TDmg{ get; set; }
	private int PDmg{ get; set; }
	private int EDef{ get; set; }


}
