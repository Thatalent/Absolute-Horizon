using UnityEngine;
using System.Collections;

public class EnemyCreation {

    private Enemy enemy;
    private int enemyID;
    private EnemyClass[] enemyMob;

    // Use this for initialization
    public EnemyCreation() {

       // EnemyCreation create = new EnemyCreation();
        //create.makeEnemy();


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

    public void makeEnemy()
    {
        int i = 0;
        // int enemyNumber = Random.Range(1, 6);
        // EnemyMob = new EnemyClass[enemyNumber];
        int enemyNumber = 0;
        EnemyMob = new EnemyClass[] { new Noob ()};
        do {
            GameObject monster= Object.Instantiate(GameObject.FindGameObjectWithTag("Enemy"));
			BattleController.EnemyMob[i]=monster;
            Debug.Log(EnemyMob[i]);
           // BattleController.EnemyMob[i].SetActive(true);
            Enemy = monster.GetComponent<Enemy>();
            Enemy.EnemyClass = EnemyMob[i];
            Debug.Log(monster.GetComponent<Enemy>().EnemyClass);
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
            Debug.Log(monster.GetComponent<Enemy>().Agility);
            addMoves(monster);
            

            i++;
        } while (i < enemyNumber);
    }

    public Enemy Enemy { get; set; }
    public int EnemyID { get; set; }
    public EnemyClass[] EnemyMob { get; set; }
}
