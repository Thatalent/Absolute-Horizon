using UnityEngine;
using System.Collections;

public class EnemyClass {

    public int Health{ get; set; }
    public int MaxHealth { get; set; }
	public int Attack{ get; set; }
	public int Defense{ get; set; }
	public int Magic{ get; set; }
	public int MagicDefense{ get; set; }
	public int Agility{ get; set; }
	public int Skill{ get; set; }
	public int Luck{ get; set; }

    public int EnergyRate{ get; set; }//energyRate is depended on endurance
	public int MaxEnergy{ get; set; }//maxEnergy is depended on stamina 
	public int Energy{ get; set; }

	public string EnemyName{ get; set; }

    private Moves[] attacks = new Moves[4];
    private Moves[] spells = new Moves[4];
    private Moves specials;

    public Moves Trigger { get; set; }
    public Moves[] Attacks { get; set; }
    public Moves[] Spells { get; set; }
    public Moves[] Specials { get; set; }


}
