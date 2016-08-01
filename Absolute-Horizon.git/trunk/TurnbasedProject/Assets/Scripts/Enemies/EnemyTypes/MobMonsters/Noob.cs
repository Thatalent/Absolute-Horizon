﻿using UnityEngine;
using System.Collections;

public class Noob : EnemyClass {

	public Noob(){
		EnemyName = "Noob";
		Health = 100;
        MaxHealth = 100;
		Attack = 13;
		Defense = 8;
		Magic = 10;
		MagicDefense = 10;
		Skill = 10;
		Agility = 10;
		Luck = 10;

		EnergyRate = (Defense + MagicDefense)/ 4;
        MaxEnergy = (Health-90) + (Attack + Magic) / 2;

       // Attacks[0] = new Stab();



	}
}
