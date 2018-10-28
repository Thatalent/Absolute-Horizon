using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sparkles : BaseMagicMove {



    public Sparkles()
    {
        Name = "Sparkles";
        //Enemy = BattleController.Enemy;
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 1.0f;
        HitRate = 1.00f;
        DmgBoost = 5;
        SpUse = -0.2f;
        MoveCount = 3;
        chant = new Queue<string>(new string[] {"oni"});

    }
    public override void move(BattleController battleController)
    {
        GameObject enemy = battleController.Enemy;
        Magic spell = new Magic((battleController.Player.Intelligence + DmgBoost), enemy.GetComponent<Enemy>().Resistance);
        int damage = spell.casting();
        enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health + damage;
        enemyStatus(damage, 0, 0, enemy);
       

    }

    /// <summary>
    /// Hides the original EpUse so a unique value can be obtain based on the player's current stats.
    /// </summary>
    /// <returns></returns>
    public new int EpUse
    {
        get
        {
            return (int)(1 / ((float)(Player.Strength + Player.Skill) / 100));
        }
    }

    /// <summary>
    /// Hides the original EpUse so a unique value can be obtain based on the player's current stats.
    /// </summary>
    /// <returns></returns>
    public new int MpUse
    {
        get
        {
            return (int)(1 / ((float)(Player.Intelligence + Player.Skill) / 100));
        }
    }
}