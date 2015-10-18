using UnityEngine;
using System.Collections;

public class Magic {

	private int tDmg;
	private int wDmg;
	private int pDmg;
	private int eDef;

	public Magic(int wDmg, int pDmg, int eDef) {
		
		this.wDmg = wDmg;
		this.pDmg = pDmg;
		this.eDef = eDef;
	}
		
	public int casting (){
			
		tDmg = eDef-(wDmg + pDmg);
			
		return tDmg;
	}
	public bool effectRate (float rate){
		
		if (1.0f - rate < Random.value) {
			return true;
		}
		return false;
	}
	private int TDmg{ get; set; }
	private int WDmg{ get; set; }
	private int PDmg{ get; set; }
	private int EDef{ get; set; }
}
