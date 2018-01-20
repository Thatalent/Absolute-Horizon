using UnityEngine;
using System.Collections;

public class Special {

	public Special (GameObject player, GameObject enemy, int eDef){

        Player = player;
        Enemy = enemy;
        EDef = eDef;

	}

    public bool effectRate(float rate)
    {

        if (1.0f - rate < Random.value)
        {
            return true;
        }
        return false;
    }

    private int TDmg{ get; set; }
	private GameObject Player{ get; set; }
	private GameObject Enemy{ get; set; }
	private int EDef{ get; set; }
}
