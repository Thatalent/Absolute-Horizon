using UnityEngine;
using System.Collections;

public class Floob : EnemyClass {

    public Floob()
    {
        EnemyName = "Noob";
        Health = 75;
        MaxHealth = 75;
        Attack = 15;
        Defense = 6;
        Magic = 10;
        MagicDefense = 6;
        Skill = 8;
        Agility = 7;
        Luck = 10;

        EnergyRate = (Defense + MagicDefense) / 4;
        MaxEnergy = (Health - 90) + (Attack + Magic) / 2;

        // Attacks[0] = new Stab();



    }
}
