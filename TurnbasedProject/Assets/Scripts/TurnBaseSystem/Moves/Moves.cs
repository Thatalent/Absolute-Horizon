using UnityEngine;
using System.Collections;

public abstract class Moves {
	
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
		//start animation	
	}
    //override to specify the actions for the move
	public virtual void move(){
        GameObject enemy = Enemy;
        if (enemy == null)
        {
            enemy = BattleController.Enemy;
        }
        Attack attack = new Attack((int)(DmgX * BattleController.Player.Attack + DmgBoost), enemy.GetComponent<Enemy>().Defense);
        int damage = attack.attacking();
        enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health + damage;
        Debug.Log("damage of move - " + Name + " is equal to:" + damage);
        enemyStatus(damage, 0, 0, enemy);
        additionalActions();
    }

    //Used to add a percentage of special points to player's gauge
	public void sepc(){

		//add a percentage of special points to player's gauge

	}

    //Used to change resources like items, energy, magic, or special
	public void resource(){
        GameInformation.Energy = GameInformation.Energy - EpUse;
        GameInformation.Mana = GameInformation.Mana - MpUse;
        GameInformation.SpecialCharge = GameInformation.SpecialCharge - SpUse;
    }
    public Transform enemyStatus(int dmg, int epDmg)
    {
        return null;
    }


    //Used to resize the enemy status bars and other status effects
    public virtual void enemyStatus(int dmg, int mpDmg, int epDmg, GameObject enemy)
    {
        if(dmg != 0)
        {
            FloatingText.Show(string.Format("{0}", dmg), "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, enemy.transform.position, 3.5f, 0));
        }
        Status status = enemy.GetComponentInChildren<BaseStatusBar>();
        status.changeStatusSize(enemy.GetComponent<Enemy>().Health, enemy.GetComponent<Enemy>().MaxHealth);
        Debug.Log("Enemy : "+ enemy.GetComponent<Enemy>().Health);

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

    /// <summary>
    /// Override this for additional actions after performing move.
    /// </summary>
    public virtual void additionalActions()
    {

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
