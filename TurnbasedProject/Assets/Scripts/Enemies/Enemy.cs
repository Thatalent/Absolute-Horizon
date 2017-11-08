using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public EnemyClass EnemyClass { get; set; }
    public string EnemyName { get; set; }
    public int Stamina { get; set; }//effects maxuim energy
    public int Strength { get; set; }//effects energy usage
    public int Endurance { get; set; }//effects energy rate
    public int Intelligence { get; set; }//effects energy usage
    public int Resistance { get; set; }//effects energy rate
    public int Speed { get; set; }//effects dodge
    public int Skill { get; set; }//effects accaracy, energy usage, and critcial  rate
    public int Luck { get; set; }//effects item drop, critical dodge, and various other things

    public int EnemyLvl { get; set; }
    public float EnemyExp { get; set; }
    public int EnergyRate { get; set; }//energyRate is depended on endurance
    public int MaxEnergy { get; set; }//maxEnergy is depended on stamina 
    public int Energy { get; set; }


    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Magic { get; set; }
    public int MagicDefense { get; set; }
    public int Agility { get; set; }

    private Moves[] attacks = new Moves[4];
    private Moves[] spells = new Moves[4];
    private Moves specials;

    public Moves Trigger { get; set; }
    public Moves[] Attacks { get; set; }
    public Moves[] Spells { get; set; }
    public Moves[] Specials { get; set; }

    public void initStats()
    {
        MaxHealth = EnemyClass.MaxHealth;
        Health = EnemyClass.Health;
        Attack = EnemyClass.Attack;
        Defense = EnemyClass.Defense;
        Skill = EnemyClass.Skill;
        Agility = EnemyClass.Agility;
        Luck = EnemyClass.Luck;
        Magic = EnemyClass.Magic;
        MagicDefense = EnemyClass.MagicDefense;
        MaxEnergy = EnemyClass.MaxEnergy;
        EnergyRate = EnemyClass.EnergyRate;
        EnemyName = EnemyClass.EnemyName;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
