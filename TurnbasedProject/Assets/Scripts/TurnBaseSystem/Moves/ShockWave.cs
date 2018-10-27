using UnityEngine;
using System.Collections;

public class ShockWave : Moves, AttackMove {

    public ShockWave()
    {
        Name = "ShockWave";
        Player = BattleController.Player;
        Debug.Log(BattleController.Player.Strength);
        //Enemy = BattleController.Enemy;
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
    public override void move(BattleController battleController)
    {
        foreach(GameObject enemy in battleController.EnemyMob){
            Attack attack = new Attack((battleController.Player.Attack + DmgBoost), enemy.GetComponent<Enemy>().Defense);
            int damage = attack.attacking();
            enemy.GetComponent<Enemy>().Health = enemy.GetComponent<Enemy>().Health + damage;
            Debug.Log("damage: " + damage);
            enemyStatus(damage, 0, 0, enemy);
        }
    }

}
