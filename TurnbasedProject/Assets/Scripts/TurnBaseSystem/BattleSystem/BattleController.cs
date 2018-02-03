 using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour, BattleControllerService
{

    public enum BattleStatus { START, ACTIVE, PENDING, END};
	// Use this for initialization
	void Start ()
	{
		Player = GameInformation.data ();
		Debug.Log ("Start of Battle!");
		ActiveBattle = true;
		Energy energy = gameObject.GetComponent<Energy> ();
		energy.enabled = true;
		BattleWaves = BattleFactoryService.getNewBattleFactory (GameInformation.PlayerLocation).generateEnemyWaves (GameInformation.PlayerLvl);
		EnemyMob =  new EnemyGenerator ().makeEnemy ();
		EnemiesAlive = EnemyMob.Length;
		NumberOfWaves = BattleWaves.Length;
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log("Player Health: " + Player.Health);
		Debug.Log ("Number of Waves: " + NumberOfWaves);
		if (Player.Health <= 0 || (EnemiesAlive == 0 && NumberOfWaves == 0)) {
			ActiveBattle = false;
		} else if (EnemiesAlive == 0 && NumberOfWaves > 0) {
			//create the next mob.
			EnemyMob = new EnemyGenerator ().makeEnemy ();
		}
		// Triggers the end of battle. This occurs when ALL waves are complete.
		if (ActiveBattle == false) {
			BattleUtils.endBattle (Player, EnemiesAlive);
			NumberOfWaves--;
		}

		EnemiesAlive = EnemyMob.Length;
	}

	public static Player Player { get; set; }
	public static GameObject Enemy { get; set; }
	public static int EnemiesAlive { get; set; }
	public static bool ActiveBattle { get; set; }
	public static GameObject[] EnemyMob { get; set; }
	public static int NumberOfWaves { get; set; }
   	public static int EnemyIndex { get; set; }
    public static BattleWave[] BattleWaves { get; set; }
}
