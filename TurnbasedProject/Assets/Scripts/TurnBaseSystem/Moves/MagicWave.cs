using UnityEngine;
using System.Collections;

public class MagicWave : Moves, SpecialMove {

    public MagicWave()
    {
        Name = "MagicWave";
        //Enemy = BattleController.Enemy;
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 2.0f;
        HitRate = 1.00f;
        DmgBoost = 0;
        EpUse = 0;
        MpUse = 0;
        SpUse = 1.0f;
    }
    public override void move(BattleController battleController)
    {   
        BattleController = battleController;
        Player = BattleController.Player;
        Model = BattleController.Model;
        Model.State = new CenterBattleMenuState(Model);
        Special special = new Special(Player, ReactionInput.InputType.RANDOM, 3f);
        special.SpecialCallback = additionalActions;
        special.perform();
    }

    public override void additionalActions()
    {
        foreach (GameObject enemy in BattleController.EnemyMob)
        {
            int netDmg = Special.getEnemyDmg(damage, enemy.GetComponent<Enemy>().Resistance);
            enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health + netDmg;
            enemyStatus(damage, 0, 0, enemy);
        }
        Model.State = new CenterBattleMenuState(Model);
    }

    public void additionalActions(int damage)
    {
        this.damage = (int)(damage * DmgX);
        additionalActions();
    }

    private int damage;
    OptionsModule Model { get; set; }

    public new int MoveCount { 
        get
        {
            return Player.MoveCounter;
        }
    }

}
