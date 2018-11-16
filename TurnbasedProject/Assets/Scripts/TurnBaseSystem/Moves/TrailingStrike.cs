using UnityEngine;
using System.Collections;

public class TrailingStrike : Moves, AttackMove {

    public TrailingStrike(GameObject enemy)
    {
        Name = "TrailingStrike";
        Enemy = enemy;
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 0.75f;
        HitRate = 1.00f;
        DmgBoost = 3;
        MpUse = 0;
        SpUse = -0.2f;
        MoveCount = 0;
        EpUse = 0;
    }

    public TrailingStrike()
    {
        Name = "TrailingStrike";
        BrnRate = 0f;
        FrzRate = 0f;
        StnRate = 0f;
        PsnRate = 0f;
        DmgX = 0.75f;
        HitRate = 1.00f;
        DmgBoost = 4;
        MpUse = 0;
        SpUse = -0.2f;
        MoveCount = 1;
    }
}
