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

	public static Player Player { get; set; }
    public static int MaxHealth { get; set; }
	public static int Health{ get; set; }
	public static int Attack{ get; set; }
	public static int Defense{ get; set; }
	public static int Magic{ get; set; }
	public static int MagicDefense{ get; set; }
    public static int Mana { get; set; }
    public static int MaxMana { get; set; }
	public static int Agility{ get; set; }
    public static float SpecialCharge { get; set; }

    public static int MoveCounter { get; set; }
    public static float MoveWait { get; set; }
	
	private static Moves[]attacks = new Moves[16]; 
	private static Moves[]spells = new Moves[16];
	private static Moves[]specials = new Moves[5];

	public static Moves Trigger{ get; set; }
	public static Moves[] Attacks{ get; set; }
	public static Moves[]Spells{ get; set; }
	public static Moves[] Specials{ get; set; }


	public static Player data(){
		Player = new Player ();
		Player.CharacterClass = GameInformtion.PlayerClass;
		Player.PlayerLvl = GameInformtion.PlayerLvl;
		Player.PlayerName = GameInformtion.PlayerName;
		Player.Stamina = GameInformtion.Stamina;
		Player.Strength = GameInformtion.Strength;
		Player.Endurance = GameInformtion.Endurance;
		Player.Intelligence = GameInformtion.Intelligence;
		Player.Resistance = GameInformtion.Resistance;
		Player.Speed = GameInformtion.Speed;
		Player.Skill = GameInformtion.Skill;
		Player.Luck = GameInformtion.Luck;
        Player.MaxHealth = GameInformtion.MaxHealth;
		Player.Health = GameInformtion.Health;
		Player.Attack = GameInformtion.Attack;
		Player.Defense = GameInformtion.Defense;
        Player.Mana = GameInformtion.Mana;
        Player.MaxMana = GameInformtion.MaxMana;
		Player.Magic = GameInformtion.Magic;
		Player.MagicDefense = GameInformtion.MagicDefense;
        Player.MaxEnergy = GameInformtion.MaxEnergy;
		Player.Energy = GameInformtion.MaxEnergy;
		Player.EnergyRate = GameInformtion.EnergyRate;
		Player.Agility = GameInformtion.Agility;
        Player.MoveCounter = MoveCounter;
        Player.MoveWait = GameInformtion.MoveWait;
		return Player;
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
        GameInformtion.MaxHealth = GameInformtion.Health;
		GameInformtion.Attack = GameInformtion.Strength;
        GameInformtion.Magic = GameInformtion.Intelligence;
		GameInformtion.MaxMana = GameInformtion.Intelligence+GameInformtion.Resistance;
		GameInformtion.Defense = GameInformtion.Endurance;
		GameInformtion.MagicDefense = GameInformtion.Resistance;
		GameInformtion.Agility = GameInformtion.Speed;
		GameInformtion.EnergyRate = (GameInformtion.Endurance+GameInformtion.Resistance) / 20;
		GameInformtion.MaxEnergy = GameInformtion.Stamina + (GameInformtion.Strength+GameInformtion.Intelligence) / 2;
        GameInformtion.Attacks = GameInformtion.attacks;
        GameInformtion.Spells = GameInformtion.spells;
        GameInformtion.Specials = GameInformtion.specials;
        SpecialCharge = 0f;
        Energy = MaxEnergy;
        Mana = MaxMana;
        MoveCounter = (Speed + Skill / 2) / 2 + PlayerLvl;
        MoveWait = (int)(800f / (Mathf.Pow(Skill + Speed, 2)));
    }


}
