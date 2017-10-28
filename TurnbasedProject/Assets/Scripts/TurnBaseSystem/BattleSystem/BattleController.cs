using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{

	private static bool monsterCreation;
	private static EnemyGenerator create;

	// Use this for initialization
	void Start ()
	{
		Player = GameInformation.data ();
		Debug.Log ("Start of Battle!");
		ActiveBattle = true;
		Energy energy = gameObject.GetComponent<Energy> ();
		energy.enabled = true;
		EnemyMob = new EnemyGenerator ().makeEnemy ();
		EnemiesAlive = EnemyMob.Length;
		monsterCreation = true;

		//TODO: Create service class that determines the number of waves based on the player's level and location
		if (Player.PlayerLvl > 25) {
			NumberOfWaves = Random.Range (1, 2);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (EnemiesAlive == 0 || Player.Health <= 0) { //TODO: Add condition for NumberOfWaves == 0 once class is set
			ActiveBattle = false;
		}
		if (GameObject.FindGameObjectWithTag ("Enemy") && !monsterCreation) {
			monsterCreation = true;
			create.makeEnemy ();
			EnemiesAlive = EnemyMob.Length;
		}
		// Triggers the end of battle. This occurs when ALL waves are complete.
		if (ActiveBattle == false) {
			BattleUtils.endBattle (Player, EnemiesAlive);
		}
		EnemiesAlive = EnemyMob.Length;
	}

	public static Player Player { get; set; }
	public static GameObject Enemy { get; set; }
	public static int EnemiesAlive { get; set; }
	public static bool ActiveBattle { get; set; }
	public static GameObject[] EnemyMob { get; set; }
	public static int NumberOfWaves { get; set; }
}
