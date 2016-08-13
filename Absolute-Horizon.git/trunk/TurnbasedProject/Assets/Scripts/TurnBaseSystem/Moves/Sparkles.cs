using UnityEngine;
using System.Collections;

public class Sparkles : Moves {



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
        Magic spell = new Magic((BattleController.Player.Intelligence + DmgBoost), BattleController.Enemy.GetComponent<Enemy>().Resistance);
        int damage = spell.casting();
        BattleController.Enemy.GetComponent<Enemy>().Health = BattleController.Enemy.GetComponent<Enemy>().Health + damage;
        enemyStatus();
       

    }


}
