using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public abstract class BaseMagicMove : Moves, MagicMove
{
    public Dictionary<string, Enchantment>  getEnchantments(){
        return this.enchantments;
    }

    public Queue<string>  getChant(){
        return this.chant;
    }

    protected Queue<string> chant;
    protected Dictionary<string, Enchantment> enchantments;
}