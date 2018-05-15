using UnityEngine;
using System.Collections;

public class Player {	
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
    public int MoveCounter { get; set; }
    public float MoveWait { get; set;}

    public int MaxHealth { get; set; }
	public int Health{ get; set; }
	public int Attack{ get; set; }
	public int Defense{ get; set;}
    public int Mana { get; set; }
    public int MaxMana { get; set; }
	public int Magic{ get; set; }
	public int MagicDefense{ get; set; }
	public int Agility{ get; set; }
	public int Energy{ get; set; }
	public int MaxEnergy{ get; set; }
	public int EnergyRate{ get; set; }
    
	public PlayerActions Actions { get; set; }
}