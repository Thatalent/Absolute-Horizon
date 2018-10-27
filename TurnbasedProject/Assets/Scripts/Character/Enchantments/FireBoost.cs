using System;
using UnityEngine;

public class FireBoost : Enchantment
{
    
    int limit = 3;

    string chant = "fir";

    public void enchant(Moves move){
        move.BrnRate += 0.15f;
    }
}
