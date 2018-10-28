using UnityEngine;
using System.Collections;

public class EnemyGenerator
{

    /// <summary>
	/// Use this for Enemy Initialization.
	/// </summary>
    public EnemyGenerator()
    {

        GameObject[] enemyPositionObjects = GameObject.FindGameObjectsWithTag("EnemyPosition");
        EnemyLocation = new Transform[enemyPositionObjects.Length];
        for (int i = 0; i < enemyPositionObjects.Length; i++)
        {
            EnemyLocation[i] = enemyPositionObjects[i].transform;
        }
    }

	/// <summary>
	/// Finds the enemy.
	/// </summary>
	/// <returns>The enemy.</returns>
    public EnemyClass findEnemy()
    {
        switch (EnemyID)
        {
            case 1: return new Noob();

            default: return null;

        }
    }

	/// <summary>
	/// Adds the moves.
	/// </summary>
	/// <param name="monster">Monster.</param>
    public void addMoves(GameObject enemy)
    {
        switch (Enemy.EnemyName)
        {
            case "Noob":
                enemy.AddComponent<NoobMoves>();
                break;
        }
    }

	/// <summary>
	/// Makes the enemy.
	/// </summary>
	/// <returns>The enemy.</returns>
    public GameObject[] makeEnemy(EnemyService enemyService)
    {
        int i = 0;
        int enemyNumber = Random.Range(1, 6);
        EnemyMob = new EnemyClass[enemyNumber];

        EnemyMob = enemyService.createEnemyMob(enemyNumber);

        GameObject[] monsterMob = new GameObject[enemyNumber];
        do
        {
            //"Enemy" will be replaced with a string {EnemyClass.Name} in order to allow for a object 
			//to be dynamically built off of the types of enemies found in EnemySelection.GetEnemyMob()
            GameObject monster = Object.Instantiate(GameObject.FindGameObjectWithTag("Enemy"));
            //   monster.SetActive(true);
            monsterMob[i] = monster;
            monsterMob[i].SetActive(true);
            Enemy = monster.GetComponent<Enemy>();
            Enemy.EnemyClass = EnemyMob[i];
            Enemy.initStats();
            monster.transform.position = EnemyLocation[i].position;
            monster.transform.rotation = EnemyLocation[i].rotation;
            monster.GetComponent<SpriteRenderer>().enabled = true;
            SpriteRenderer[] monsterSpriteArray = monster.GetComponentsInChildren<SpriteRenderer>();
            for (int j = 0; j < monsterSpriteArray.Length; j++)
            {
                monsterSpriteArray[j].enabled = true;
            }
            addMoves(monster);
            i++;
        } while (i < enemyNumber);
        return monsterMob;
    }

	/// <summary>
	/// Gets the enemy types.
	/// </summary>
	/// <returns>The enemy types.</returns>
	/// <param name="enemyNumber">Enemy number.</param>
    virtual public EnemyClass[] getEnemyTypes(int enemyNumber)
    {
        EnemyClass[] listOfEnemies = new EnemyClass[enemyNumber];
        switch (GameInformation.PlayerClass.CharacterClassName)
        {
            case "Student":
                string[] potentialEnemies = { "Floob", "Noob" };
                break;

            default: break;
        }
        return listOfEnemies;
    }

    public Enemy Enemy { get; set; }
    public int EnemyID { get; set; }
    public EnemyClass[] EnemyMob { get; set; }
    public Transform[] EnemyLocation { get; set; }
    public EnemyFactory EnemyService { get; set; }
}
