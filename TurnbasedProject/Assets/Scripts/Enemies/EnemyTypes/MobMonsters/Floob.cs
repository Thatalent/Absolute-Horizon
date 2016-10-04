using UnityEngine;
using System.Collections;

public class Floob : EnemyClass, World2
{
    public int location;
    public Floob()
    {
        EnemyName = "Floob";
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

        location = 4;

        // Attacks[0] = new Stab();
    }

    public int getLocation()
    {
        Debug.Log("Floob Location returned " + location);
        return location;
    }
}
