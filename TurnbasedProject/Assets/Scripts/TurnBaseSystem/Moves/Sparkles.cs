using UnityEngine;
using System.Collections;

public class Sparkles : Moves, MagicMove {



    public Sparkles()
    {
        Name = "Sparkles";
        Player = BattleController.Player;
        Debug.Log(BattleController.Player.Strength);
        //Enemy = BattleController.Enemy;
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 1.0f;
        HitRate = 1.00f;
        DmgBoost = 5;
        EpUse = (int)(1 / ((float)(BattleController.Player.Strength + BattleController.Player.Skill) / 100));
        MpUse = (int)(1/ ((float)(BattleController.Player.Intelligence + BattleController.Player.Skill) / 100));
        Debug.Log(MpUse);
        SpUse = -0.2f;
        MoveCount = 3;


    }
    public override void move()
    {
        GameObject enemy = BattleController.Enemy;
        Magic spell = new Magic((BattleController.Player.Intelligence + DmgBoost), enemy.GetComponent<Enemy>().Resistance);
        int damage = spell.casting();
        enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health + damage;
        enemyStatus(damage, 0, 0, enemy);
       

    }
}