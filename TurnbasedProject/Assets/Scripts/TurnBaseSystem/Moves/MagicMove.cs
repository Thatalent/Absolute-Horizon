using System;
using UnityEngine;
using System.Collections.Generic;


public interface MagicMove
{

    Queue<string> getChant();
    Dictionary<string, Enchantment>  getEnchantments();
}

