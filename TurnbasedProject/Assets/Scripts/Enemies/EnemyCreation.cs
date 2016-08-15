using UnityEngine;
using System.Collections;

public class EnemyCreation {

    // Use this for initialization
    public EnemyCreation() {

        GameObject[] enemyPositionObjects = GameObject.FindGameObjectsWithTag("EnemyPosition");
        EnemyLocation = new Transform[enemyPositionObjects.Length];
        for(int i = 0; i < enemyPositionObjects.Length; i++)
        {
            EnemyLocation[i] = enemyPositionObjects[i].transform;
        }
    }

    public EnemyClass findEnemy() {
        switch (EnemyID) {
            case 1: return new Noob();

            default: return null;

        }
    }
    public void addMoves(GameObject monster)
    {
        switch (Enemy.EnemyName)
        {
            case "Noob": monster.AddComponent<NoobMoves>();
                break;
        }
    }

    public GameObject[] makeEnemy()
    {
        int i = 0;
        int enemyNumber = Random.Range(1, 6);
        EnemyMob = new EnemyClass[enemyNumber];
      //  EnemyMob = new EnemyClass[] { new Noob ()};
        
        GameObject[] monsterMob = new GameObject[enemyNumber];
        do {
            GameObject monster= Object.Instantiate(GameObject.FindGameObjectWithTag("Enemy"));
         //   monster.SetActive(true);
			monsterMob[i]=monster;
            monsterMob[i].SetActive(true);
            Enemy = monster.GetComponent<Enemy>();
            Enemy.EnemyClass = EnemyMob[i];
            Enemy.MaxHealth = Enemy.EnemyClass.MaxHealth;
            Enemy.Health = Enemy.EnemyClass.Health;
            Enemy.Attack = Enemy.EnemyClass.Attack;
            Enemy.Defense = Enemy.EnemyClass.Defense;
            Enemy.Skill = Enemy.EnemyClass.Skill;
            Enemy.Agility = Enemy.EnemyClass.Agility;
            Enemy.Luck = Enemy.EnemyClass.Luck;
            Enemy.Magic = Enemy.EnemyClass.Magic;
            Enemy.MagicDefense = Enemy.EnemyClass.MagicDefense;
            Enemy.MaxEnergy = Enemy.EnemyClass.MaxEnergy;
            Enemy.EnergyRate = Enemy.EnemyClass.EnergyRate;
            Enemy.EnemyName = Enemy.EnemyClass.EnemyName;
            monster.transform.position = EnemyLocation[i].position;
            monster.transform.rotation = EnemyLocation[i].rotation;
            monster.GetComponent<SpriteRenderer>().enabled = true;
            SpriteRenderer[] monsterSpriteArray = monster.GetComponentsInChildren<SpriteRenderer>();
            for(int j=0;j<monsterSpriteArray.Length;j++)
            {
                monsterSpriteArray[j].enabled = true;
            }
            addMoves(monster);
            

            i++;
        } while (i < enemyNumber);
        return monsterMob;
    }

    virtual
    public EnemyClass[] getEnemyTypes(int enemyNumber)
    {
        EnemyClass[] listOfEnemies = new EnemyClass[enemyNumber];
        switch (GameInformation.PlayerClass.CharacterClassName)
        {
            case "Student": listOfEnemies = new Enemies_for_Student().getEnemyTypes(enemyNumber);
                break;
            case "Royal": listOfEnemies = new Enemies_for_Royalty().getEnemyTypes(enemyNumber);
                break;

            default: break;
        }
        return listOfEnemies;
    }

    public Enemy Enemy { get; set; }
    public int EnemyID { get; set; }
    public EnemyClass[] EnemyMob { get; set; }
    public Transform[] EnemyLocation { get; set; }
}
