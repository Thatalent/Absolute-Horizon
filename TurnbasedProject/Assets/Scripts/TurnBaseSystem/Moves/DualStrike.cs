using UnityEngine;
using System.Collections;

public class DualStrike : Moves, AttackMove {

    public DualStrike()
    {
        Name = "DualStrike";
        Player = BattleController.Player;
        Debug.Log(BattleController.Player.Strength);
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 1.0f;
        HitRate = 1.00f;
        DmgBoost = 4;
        EpUse = (int)(1 / ((float)(BattleController.Player.Strength + BattleController.Player.Skill) / 100));
        MpUse = 0;
        SpUse = -0.2f;
        MoveCount = 4;
    }

   public override void additionalActions()
    {
        if (BattleController.ActiveBattle)
        {
            Moves secondAttack = new TrailingStrike(Options.getNextEnemy(BattleController.EnemyIndex));
            secondAttack.move();
        }
    }
}
