using UnityEngine;
using System.Collections;

public abstract class BattleFactoryService : BattleFactory {

    /// <summary>
    /// Returns a new instance of an implement child class for Battle Factory based on the player's location in the game universe.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
	static public BattleFactory getNewBattleFactory(PlayerLocation location)
    {

    }
}
