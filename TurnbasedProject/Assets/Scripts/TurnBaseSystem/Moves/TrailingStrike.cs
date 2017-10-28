using UnityEngine;
using System.Collections;

public class TrailingStrike : Moves {

    public TrailingStrike(GameObject enemy)
    {
        Name = "TrailingStrike";
        Player = BattleController.Player;
        Debug.Log(BattleController.Player.Strength);
        Enemy = enemy;
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 0.75f;
        HitRate = 1.00f;
        DmgBoost = 2;
        EpUse = (int)(1 / ((float)(BattleController.Player.Strength + BattleController.Player.Skill) / 100));
        MpUse = 0;
        SpUse = -0.2f;
        MoveCount = 0;
    }

    public TrailingStrike()
    {
        Name = "TrailingStrike";
        Player = BattleController.Player;
        Debug.Log(BattleController.Player.Strength);
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 0.75f;
        HitRate = 1.00f;
        DmgBoost = 2;
        EpUse = (int)(1 / ((float)(BattleController.Player.Strength + BattleController.Player.Skill) / 100));
        MpUse = 0;
        SpUse = -0.2f;
        MoveCount = 1;
    }
    public override void move()
    {
        GameObject enemy = BattleController.Enemy;
        Attack attack = new Attack((BattleController.Player.Attack + DmgBoost), enemy.GetComponent<Enemy>().Defense);
        int damage = attack.attacking();
        enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health + damage;
        Debug.Log("damage: " + damage);
        enemyStatus(damage, 0, 0, enemy);
    }
}
