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


	
    //Use to specify how accuracy is handled by the move
	public virtual float accuracy(){
        playerStatus();
        float hit=(BattleController.Player.Skill/BattleController.Enemy.GetComponent<Enemy>().Agility)*HitRate;
		return hit;
		
	}
	public void animate(){
		//start amination	
	}
    //override to specify the actions for the move
	public virtual void move(){

	}

    //Used to add a percentage of special points to player's gauage
	public void sepc(){

		//add a percentage of special points to player's gauage

	}

    //Used to change resources like items, energy, magic, or special
	public void resource(){
        GameInformation.Energy = GameInformation.Energy - EpUse;
        GameInformation.Mana = GameInformation.Mana - MpUse;
        GameInformation.SpecialCharge = GameInformation.SpecialCharge - SpUse;
    }


    //Used to resize the enemy status bars and other status effects
	public virtual void enemyStatus(int dmg, int mpDmg, int epDmg)
    {
        if(dmg != 0)
        {
            FloatingText.Show(string.Format("{0}", dmg), "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, BattleController.Enemy.transform.position, 1.5f, 1));
        }
        Status status = BattleController.Enemy.GetComponentInChildren<BaseStatusBar>();
        status.changeStatusSize(BattleController.Enemy.GetComponent<Enemy>().Health, BattleController.Enemy.GetComponent<Enemy>().MaxHealth);
        Debug.Log("Enemy : "+BattleController.Enemy.GetComponent<Enemy>().Health);

        // Uncomment for future use. 
        //Used to create pop up text when changing the mana and energy points of the Enemey
     /*   if (mpDmg != 0)
        {
            FloatingText.Show(string.Format("-{0}", mpDmg), "EnemyManaTaken", new FromWorldPointPositioner(Camera.main, BattleController.Enemy.transform.position, 1.5f, 50));
        }

        if (epDmg != 0)
        {
            FloatingText.Show(string.Format("-{0}", epDmg), "EnemyEnergyTaken", new FromWorldPointPositioner(Camera.main, BattleController.Enemy.transform.position, 1.5f, 50));
        }*/
    }
    public virtual void playerStatus()
    {
        Status healthStatus = GameObject.FindGameObjectWithTag("Player_HealthBar").GetComponent<Status>();
        healthStatus.changeStatusSize(GameInformation .Health, GameInformation.MaxHealth);

        Status magicStatus = GameObject.FindGameObjectWithTag("Player_MagicBar").GetComponent<Status>();
        magicStatus.changeStatusSize(GameInformation.Mana, GameInformation.MaxMana);

        Energy.energyStatus();
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
