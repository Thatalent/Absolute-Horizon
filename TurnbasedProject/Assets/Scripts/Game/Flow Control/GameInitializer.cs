using UnityEngine;
using System.Collections;

public class GameInitializer 
{
	public static void startGame(){


		setLocation(false);
		EnemySelection.world1SetEnemyList();
        
	}

	public static void setLocation(bool hasSavedFile){

		if(!hasSavedFile){
			GameInformation.World = 0;
            GameInformation.Zone = 0;
            GameInformation.Location = 0;
            GameInformation.Area = 0;
		}
	}
}
