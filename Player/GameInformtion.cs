using UnityEngine;
using System.Collections;

public class GameInformtion : MonoBehaviour {

	void Awake (){
		DontDestroyOnLoad (transform.gameObject);
	}
	public static BaseCharacterClass PlayerClass { get; set; }
	public static string PlayerName{ get; set; }
	public static int Stamina{ get; set;  }
	public static int Strength{ get; set; }//effects energy usage
	public static int Endurance{ get; set; }
	public static int Intelligence{ get; set; }
	public static int Resistance{ get; set; }
	public static int Speed{ get; set; }
	public static int Skill{ get; set; }
	public static int Luck{ get; set; }

	public static int PlayerLvl{ get; set; }
	public static float PlayerExp{ get; set; }
	public static int EnergyRate{ get; set; }//energyRate is depended on endurance
	public static int MaxEnergy{ get; set; }//maxEnergy is depended on stamina 
	public static int Energy{ get; set; }

	
	public static int Health{ get; set; }
	public static int Attack{ get; set; }
	public static int Defense{ get; set; }
	public static int Magic{ get; set; }
	public static int MagicDefense{ get; set; }
	public static int Agility{ get; set; }
	
	public static Moves[]attacks = new Moves[16]; 
	private static Moves[]spells = new Moves[16];
	private static Moves[]specials = new Moves[5];

	public static Moves Trigger{ get; set; }
	public static Moves[] Attacks{ get; set; }
	public static Moves[]Spells{ get; set; }
	public static Moves[] Specials{ get; set; }


	public static Player data(){
		Player player = new Player ();
		player.CharacterClass = GameInformtion.PlayerClass;
		player.PlayerLvl = GameInformtion.PlayerLvl;
		player.PlayerName = GameInformtion.PlayerName;
		player.Stamina = GameInformtion.Stamina;
		player.Strength = GameInformtion.Strength;
		player.Endurance = GameInformtion.Endurance;
		player.Intelligence = GameInformtion.Intelligence;
		player.Resistance = GameInformtion.Resistance;
		player.Speed = GameInformtion.Speed;
		player.Skill = GameInformtion.Skill;
		player.Luck = GameInformtion.Luck;
		player.Health = GameInformtion.Health;
		player.Attack = GameInformtion.Attack;
		player.Defense = GameInformtion.Defense;
		player.Magic = GameInformtion.Magic;
		player.MagicDefense = GameInformtion.MagicDefense;
		player.Energy = GameInformtion.MaxEnergy;
		player.EnergyRate = GameInformtion.EnergyRate;
		player.Agility = GameInformtion.Agility;
		return player;
	}

	public static void save(Player player){
		GameInformtion.PlayerClass =  player.CharacterClass;
		GameInformtion.PlayerLvl = player.PlayerLvl;
		GameInformtion.PlayerName = player.PlayerName ;
		GameInformtion.Stamina =player.Stamina  ;
		GameInformtion.Strength= player.Strength ;
		GameInformtion.Endurance= player.Endurance ;
		GameInformtion.Intelligence= player.Intelligence ;
		GameInformtion.Resistance= player.Resistance ;
		GameInformtion.Speed= player.Speed ;
		GameInformtion.Skill = player.Skill;
		GameInformtion.Luck= player.Luck ;
		GameInformtion.Health = GameInformtion.Stamina + 90;
		GameInformtion.Attack = GameInformtion.Strength;
		GameInformtion.Magic = GameInformtion.Intelligence;
		GameInformtion.Defense = GameInformtion.Endurance;
		GameInformtion.MagicDefense = GameInformtion.Resistance;
		GameInformtion.Agility = GameInformtion.Speed;
		GameInformtion.EnergyRate = (GameInformtion.Endurance+GameInformtion.Resistance) / 20;
		GameInformtion.MaxEnergy = GameInformtion.Stamina + (GameInformtion.Strength+GameInformtion.Intelligence) / 2;
		GameInformtion.Energy= GameInformtion.MaxEnergy ;
	}


}
