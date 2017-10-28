using UnityEngine;
using System.Collections;

public class EnemyCreation
{

    // Use this for initialization
    public EnemyCreation()
    {

        GameObject[] enemyPositionObjects = GameObject.FindGameObjectsWithTag("EnemyPosition");
        EnemyLocation = new Transform[enemyPositionObjects.Length];
        for (int i = 0; i < enemyPositionObjects.Length; i++)
        {
            EnemyLocation[i] = enemyPositionObjects[i].transform;
        }
    }

    public void addMoves(GameObject monster)
    {
        switch (Enemy.EnemyName)
        {
            case "Noob":
                monster.AddComponent<NoobMoves>();
                break;
        }
    }

    public GameObject[] makeEnemy()
    {
        int i = 0;
        int enemyNumber = Random.Range(1, 6);
        EnemyMob = new EnemyClass[enemyNumber];
        EnemyService = EnemyServiceFactory.newEnemyService("TestWorld");
        EnemyMob = EnemyService.createAndReturnEnemyMob(enemyNumber);

        GameObject[] monsterMob = new GameObject[enemyNumber];
        do
        {
            //"Enemy" will be replaced with a string {EnemyClass.Name} in order to allow for a object to be dynamically built off of the types of enemies found in EnemySelection.GetEnemyMob()
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
    public EnemyService EnemyService { get; set; }
}
