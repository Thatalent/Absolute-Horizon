using UnityEngine;
using System.Collections;

public class MagicWave : Moves {

    public MagicWave()
    {
        Name = "MagicWave";
        Player = BattleController.Player;
        Debug.Log(BattleController.Player.Strength);
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
        MoveCount = Player.MoveCounter;
    }
    public override void move()
    {
        Options.InputType = Options.UserActionType.REACTION;
        Special special = new Special(BattleController.Player, ReactionInput.InputType.RANDOM, 3f);
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
        Options.InputType = Options.UserActionType.COMMANDS;
    }

    public void additionalActions(int damage)
    {
        this.damage = (int)(damage * DmgX);
        additionalActions();
    }

    private int damage;
}
