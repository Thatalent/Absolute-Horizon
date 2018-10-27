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
		Enemy = EnemyMob[EnemyIndex];
		setUpOptions();
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

	public void setUpOptions()
	{
		Model = OptionsModule.start(Player.Actions);
		Model.battleController = this;
		Options.battleController = this;
		Options.loadMoves();
		//TODO: Danjamin add start up method for OptionsView here.
	}


    /// <summary>
    /// Gets the next active enemy in battleController.Enemymob that has health above 0 by incrementing the index of enemy mob by one.
    /// </summary>
    /// <param name="enemyIndex"></param>
    /// <returns></returns>
    public GameObject getNextEnemy(int enemyIndex)
    {
        if (++enemyIndex >= EnemyMob.Length)
        {
            enemyIndex = 0;
        }
        GameObject possibleEnemy = EnemyMob[enemyIndex];

      if (possibleEnemy == null || !EnemyMob[enemyIndex].activeInHierarchy || possibleEnemy.GetComponent<Enemy>().Health <= 0)
            {

            possibleEnemy = getNextEnemy(enemyIndex);
            }
      else
        {
            EnemyIndex = enemyIndex;
        }
        return possibleEnemy;
    }

    /// <summary>
    /// Gets the previous active enemy in battleController.Enemymob that has health above 0 by decrementing the index by one.
    /// </summary>
    /// <param name="enemyIndex"></param>
    /// <returns>The previous enemy as a GameObject</returns>
    public GameObject getPreviousEnemy(int enemyIndex)
    {
        if(--enemyIndex < 0)
        {
            enemyIndex = EnemyMob.Length - 1;
        }
        GameObject possibleEnemy = EnemyMob[enemyIndex];

        if (possibleEnemy == null || !EnemyMob[enemyIndex].activeInHierarchy || possibleEnemy.GetComponent<Enemy>().Health <= 0)
        {

            possibleEnemy = getPreviousEnemy(enemyIndex);
        }
        else
        {
            EnemyIndex = enemyIndex;
        }
        return possibleEnemy;
    }

	public Player Player { get; set; }
	public OptionsModule Model;
	public GameObject Enemy { get; set; }
	public int EnemiesAlive { get; set; }
	public bool ActiveBattle { get; set; }
	public bool ActiveEnemy { get; set; }
	public GameObject[] EnemyMob { get; set; }
	public int NumberOfWaves { get; set; }
   	public int EnemyIndex { get; set; }
}
