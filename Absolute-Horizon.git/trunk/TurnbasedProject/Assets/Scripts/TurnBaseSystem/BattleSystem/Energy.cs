using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	//private static Player player;

	// Use this for initialization
	void Start () {
        //Player = GameInformtion.data ();
        StartCoroutine(energyRate());

    }

    // Update is called once per frame
    void Update () {

    }
    IEnumerator energyRate(){
		bool battle = BattleController.Battle;
        //Debug.Log(GameInformtion.Energy);
		while(battle) {
            yield return new WaitForSeconds(1);
			if (GameInformtion.Energy < GameInformtion.MaxEnergy & !OptionsModule.ActiveTurn) {
				GameInformtion.Energy = GameInformtion.Energy + GameInformtion.EnergyRate;
                energyStatus();
            //yield return new WaitForSeconds(10);
				Debug.Log(GameInformtion.Energy);
				if (GameInformtion.Energy > GameInformtion.MaxEnergy) {
					GameInformtion.Energy = GameInformtion.MaxEnergy;
                    energyStatus();
                  //  yield return new WaitForSeconds(2f);
				}
			}
          if (GameInformtion.Energy < 0)
            {
                GameInformtion.Energy = 0;
                energyStatus();
            }
            else if (OptionsModule.ActiveTurn)
            {
                yield return new WaitForEndOfFrame();
            }
		}
	}
    static public void energyStatus() {
        Status energyStatus = GameObject.FindGameObjectWithTag("Player_EnergyBar").GetComponent<Status>();
        energyStatus.changeStatusSize(GameInformtion.Energy, GameInformtion.MaxEnergy);
    }
	//public static Player Player{ get; set; }
}
