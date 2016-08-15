using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void Awake (){
		DontDestroyOnLoad (transform.gameObject);
	}
	public static BaseCharacterClass PlayerClass { get; set; }
	public static string PlayerName{ get; set; }



    ///<summary>
    ///Calls and sets the Stamina of the Player on GameInformation.
    /// 
    ///<para> Health is solely dependant on Stamina.</para>
    /// 
    ///<para>Stamina also influences the Maximum Enegry a player can have at one time.</para>
    ///</summary>	
    /// <param name="Stamina">Stamina</param>
    /// <returns>Stamina</returns>
    public static int Stamina{ get; set;  }
    ///<summary>
    ///Calls and sets the Strength of the Player on GameInformation.
    /// <para>Attack is solely dependant on Stength</para>
    /// <para>Strength also influences the Maximum Enegry a player can have at one time.</para>
    ///</summary>	
    /// <param name="Strength">Stamina</param>
    /// <returns>Stamina</returns>
    public static int Strength{ get; set; }
    ///<summary>
    ///Calls and sets the Endurance of the Player on GameInformation.
    /// <para>Defense is solely dependant on Endurance</para>
    /// <para>Endurance also influences the Enegry rate a player recovers at atime.</para>
    ///</summary>	
    /// <param name="Endurance">Stamina</param>
    /// <returns>Enduurance</returns>
    public static int Endurance{ get; set; }
    ///<summary>
    ///Calls and sets the Intelligence of the Player on GameInformation.
    /// <para>Magic is solely dependant on Intelligence</para>
    /// <para>Intelligence also influences the Maximum Enegry a player can have at one time.</para>
    ///</summary>	
    /// <param name="Intelligence">Inteligence</param>
    /// <returns>Intelligence</returns>
    public static int Intelligence{ get; set; }
    ///<summary>
    ///Calls and sets the Resistance of the Player on GameInformation.
    /// <para>Magic Defense is solely dependant on Resistence</para>
    /// <para>Strength also influences the the rate of Energy a player can recover at one time.</para>
    ///</summary>	
    /// <param name="Resistance">Resistance</param>
    /// <returns>Resistance</returns>
    public static int Resistance{ get; set; }
    ///<summary>
    ///Calls and sets the Speed of the Player on GameInformation.
    /// <para>Agility is solely dependant on Speed</para>
    /// <para>Speed also influences the MoveCount and MoveWait.</para>
    ///</summary>	
    /// <param name="Speed">Speed</param>
    /// <returns>Speed</returns>
    public static int Speed{ get; set; }
    ///<summary>
    ///Calls and sets the Skill of the Player on GameInformation.
    /// <para>The accuracy of a hit is solely dependant on Skill</para>
    /// <para>Skill also influences the MoveCount, critical hits and MoveWait.</para>
    ///</summary>	
    /// <param name="Skill">Skill</param>
    /// <returns>Skill</returns>	
    public static int Skill{ get; set; }
    ///<summary>
    ///Calls and sets the Luck of the Player on GameInformation.
    /// <para>Items drop is solely dependant on Luck</para>
    /// <para>Luck also influences the critical hit, money drop, leveling and various aspects of the game.</para>
    ///</summary>	
    /// <param name="Luck">Luck</param>
    /// <returns>Luck</returns>	
    public static int Luck{ get; set; }

    ///<summary>
    ///Calls and sets the Player level of the Player on GameInformation.
    ///</summary>	
    public static int PlayerLvl{ get; set; }

    ///<summary>
    ///Calls and sets the Player Experience of the Player on GameInformation.
    ///</summary>	
    public static float PlayerExp{ get; set; }

    ///<summary>
    ///Calls and sets the Enerhy Rate of the Player on GameInformation.
    ///</summary>	
    public static int EnergyRate{ get; set; }

    ///<summary>
    ///Calls and sets the Maximum Energy of the Player on GameInformation.
    ///</summary>	
    public static int MaxEnergy{ get; set; }

    ///<summary>
    ///Calls and sets the current Energy of the Player on GameInformation.
    ///</summary>	
    public static int Energy{ get; set; }

    ///<summary>
    ///Calls and sets the Player on GameInformation.
    ///</summary>	
    public static Player Player { get; set; }
    ///<summary>
    ///Calls and sets the Maximum of the Player on GameInformation.
    ///</summary>	
    public static int MaxHealth { get; set; }

    ///<summary>
    ///Calls and sets the current Health of the Player on GameInformation.
    ///</summary>	
    public static int Health{ get; set; }

    ///<summary>
    ///Calls and sets the current Attack of the Player on GameInformation.
    ///</summary>	
    public static int Attack{ get; set; }

    ///<summary>
    ///Calls and sets the Defense of the Player on GameInformation.
    ///</summary>	
    public static int Defense{ get; set; }

    ///<summary>
    ///Calls and sets the current Magic of the Player on GameInformation.
    ///</summary>	
    public static int Magic{ get; set; }

     ///<summary>
    ///Calls and sets the Stamina of the Player on GameInformation.
    /// 
    /// Health is solely dependant on Stamina.
    /// 
    /// Stamina also influences the Maximum Enegry a player can have at one time.
    ///</summary>	
    /// <return>MagicDefense</return>
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

    ///<summary>
    /// Creates a Player from the current information in 
    /// <para>Tracks the following:</para>
    /// <list>CharacterClass</list>
    /// <list type="Fields">PlayerLvl</list>
    /// <list type="PlayerName">PlayerName</list>
    /// <list type="Stamina">Stamina</list>
    /// <list type="Strength">Strength</list>
    /// <list type="Endurance">Endurance</list>
    /// <list type="Intelligence">Intelligence</list>
    /// <list type="Resistance">Resistance</list>
    /// <list type="Speed">Speed</list>
    /// <list type="Skill">Skill</list>
    /// <list type="Luck">Luck</list>
    /// <list type="MaxHealth">MaxHealth</list>
    /// <list type="Health">Health</list>
    /// <list type="Attack">Attack</list>
    /// <list type="Defense">Defense</list>
    /// <list type="Mana">Mana</list>
    /// <list type="MaxMana">MaxMana</list>
    /// <list type="Magic">Magic</list>
    /// <list type="MagicDefense">MagicDefense</list>
    /// <list type="MaxEnergy">MaxEnergy</list>
    /// <list type="Energy">Energy</list>
    /// <list type="Agility">Agility</list>
    /// <list type="MoveCounter">MoveCounter</list>
    /// <list type="MoveWait">MoveWait</list>
    ///</summary>	
    /// <returns>Player</returns>
    public static Player data(){
		Player = new Player ();
		Player.CharacterClass = GameInformation.PlayerClass;
		Player.PlayerLvl = GameInformation.PlayerLvl;
		Player.PlayerName = GameInformation.PlayerName;
		Player.Stamina = GameInformation.Stamina;
		Player.Strength = GameInformation.Strength;
		Player.Endurance = GameInformation.Endurance;
		Player.Intelligence = GameInformation.Intelligence;
		Player.Resistance = GameInformation.Resistance;
		Player.Speed = GameInformation.Speed;
		Player.Skill = GameInformation.Skill;
		Player.Luck = GameInformation.Luck;
        Player.MaxHealth = GameInformation.MaxHealth;
		Player.Health = GameInformation.Health;
		Player.Attack = GameInformation.Attack;
		Player.Defense = GameInformation.Defense;
        Player.Mana = GameInformation.Mana;
        Player.MaxMana = GameInformation.MaxMana;
		Player.Magic = GameInformation.Magic;
		Player.MagicDefense = GameInformation.MagicDefense;
        Player.MaxEnergy = GameInformation.MaxEnergy;
		Player.Energy = GameInformation.MaxEnergy;
		Player.EnergyRate = GameInformation.EnergyRate;
		Player.Agility = GameInformation.Agility;
        Player.MoveCounter = MoveCounter;
        Player.MoveWait = GameInformation.MoveWait;
		return Player;
	}

	public static void save(Player player){
		GameInformation.PlayerClass =  player.CharacterClass;
		GameInformation.PlayerLvl = player.PlayerLvl;
		GameInformation.PlayerName = player.PlayerName ;
		GameInformation.Stamina =player.Stamina  ;
		GameInformation.Strength= player.Strength ;
		GameInformation.Endurance= player.Endurance ;
		GameInformation.Intelligence= player.Intelligence ;
		GameInformation.Resistance= player.Resistance ;
		GameInformation.Speed= player.Speed ;
		GameInformation.Skill = player.Skill;
		GameInformation.Luck= player.Luck ;
		GameInformation.Health = GameInformation.Stamina + 90;
        GameInformation.MaxHealth = GameInformation.Health;
		GameInformation.Attack = GameInformation.Strength;
        GameInformation.Magic = GameInformation.Intelligence;
		GameInformation.MaxMana = GameInformation.Intelligence+GameInformation.Resistance;
		GameInformation.Defense = GameInformation.Endurance;
		GameInformation.MagicDefense = GameInformation.Resistance;
		GameInformation.Agility = GameInformation.Speed;
		GameInformation.EnergyRate = (GameInformation.Endurance+GameInformation.Resistance) / 20;
		GameInformation.MaxEnergy = GameInformation.Stamina + (GameInformation.Strength+GameInformation.Intelligence) / 2;
        GameInformation.Attacks = GameInformation.attacks;
        GameInformation.Spells = GameInformation.spells;
        GameInformation.Specials = GameInformation.specials;
        SpecialCharge = 0f;
        Energy = MaxEnergy;
        Mana = MaxMana;
        MoveCounter = (Speed + Skill / 2) / 2 + PlayerLvl;
        MoveWait = (int)(800f / (Mathf.Pow(Skill + Speed, 2)));
    }


}
