using UnityEngine;
using System.Collections;

public class Moves {
	
	private Player player;
	private GameObject enemy;

	private string name;

	private float brnRate;
	private float frzRate;
	private float stnRate;
	private float psnRate;
	private float hitRate;
	private float dmgX;
	private int dmgBoost;
	private int epUse;
	private int mpUse;
	private float spUse;
    private int moveCount;


	

	public virtual float accuracy(){
		float hit=(BattleController.Player.Skill/BattleController.Enemy.GetComponent<Enemy>().Agility)*HitRate;
		return hit;
		
	}
	public void animate(){
		//start amination	
	}
	public virtual void move(){

	}

	public void sepc(){

		//add a percentage of special points to player's gauage

	}
	public void resource(){
		//subtruct from items, energy, magic or special points
	}
	

	public Player Player{ get; set; }
	public GameObject Enemy{ get; set;}
	public float BrnRate{ get; set; }
	public float FrzRate{ get; set; }
	public float StnRate{ get; set; } 
	public float PsnRate{ get; set; }
	public float HitRate{ get; set; }
	public float DmgX{ get; set; }
	public int DmgBoost{ get; set; }
	public int EpUse{ get; set; }
	public int MpUse{ get; set; }
	public float SpUse{ get; set; }
	public string Name{ get; set; }
    public int MoveCount { get; set; }




}
