using System;
using UnityEngine;

public class FireBoost : Enchantment
{
    
    private int limit = 3;

    private string chant = "fir";

    public void enchant(Moves move){
        move.BrnRate += 0.15f;
    }
}
