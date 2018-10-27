using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public abstract class BaseMagicMove : Moves, MagicMove
{
    public string getEnchantments(){
        return this.enchantments;
    }

    public string getEnchantments(){
        return this.chant;
    }

    protected Queue<string> chant;
    protected Dictionary<string, Enchantment> enchantments;
}