using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

	private static Player player;
	private static bool battle;
	private static int enemies=1;
	private static GameObject enemy;
	private static bool monsterCreation;
	private static GameObject[] enemyMob;



	// Use this for initialization
	void Start () {
		BattleController.Player = GameInformation.data();
		Debug.Log ("BattleController.Player=null");
		BattleController.Battle = true;
		//enemies = Random.Range (1, 6);
		//for (int i=0; i<enemies; i++) {
		//Code to create new enemy
		//}
		Energy energy = gameObject.GetComponent<Energy> ();
		energy.enabled = true;
		EnemyMob = new GameObject[6];
	}
	
	// Update is called once per frame
	void Update () {
		if (enemies == 0) {
			Battle=false;
		}
		if (GameObject.FindGameObjectWithTag("Enemy")&& !monsterCreation){
			monsterCreation=true;
			EnemyCreation create=new EnemyCreation ();
			create.makeEnemy();

		}

	}

	public static Player Player{ get; set; }
	public static GameObject Enemy{ get; set; }
	public static int Enemies{ get; set; }
	public static bool Battle{ get; set; }
	public static GameObject[] EnemyMob{ get; set; }
}
