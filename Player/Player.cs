using UnityEngine;
using System.Collections;

public class Player {

	private BaseCharacterClass characterClass;
	private int stamina;
	private int strength;
	private int endurance;
	private int intelligence;
	private int resistance;
	private int speed;
	private int skill;
	private int luck;

	private int playerLvl;
	private float playerExp;
	private string playerName;

	private int health;
	private int attack;
	private int defense;
	private int magic;
	private int magicDefense;
	private int agility;
	private int energy;


	
	public BaseCharacterClass CharacterClass{ get; set; }
	public int Stamina{ get; set; }
	public int Strength{ get; set; }
	public int Endurance{ get; set; }
	public int Intelligence{ get; set; }
	public int Resistance{ get; set; }
	public int Speed{ get; set; }
	public int Skill{ get; set; }
	public int Luck{ get; set; }

	public int PlayerLvl{ get; set; }
	public float PlayerExp{ get; set; }
	public string PlayerName{ get; set; }

	public int Health{ get; set; }
	public int Attack{ get; set; }
	public int Defense{ get; set; }
	public int Magic{ get; set; }
	public int MagicDefense{ get; set; }
	public int Agility{ get; set; }
	public int Energy{ get; set; }
	public int MaxEnergy{ get; set; }
	public int EnergyRate{ get; set; }
}
