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
		bool battle = battleController.ActiveBattle;
        //Debug.Log(GameInformtion.Energy);
		while(battle) {
            yield return new WaitForSeconds(1);
			if (GameInformation.Energy < GameInformation.MaxEnergy & !battleController.Model.ActiveTurn) {
				GameInformation.Energy = GameInformation.Energy + GameInformation.EnergyRate;
                energyStatus();
            //yield return new WaitForSeconds(10);
				Debug.Log(GameInformation.Energy);
				if (GameInformation.Energy > GameInformation.MaxEnergy) {
					GameInformation.Energy = GameInformation.MaxEnergy;
                    energyStatus();
                  //  yield return new WaitForSeconds(2f);
				}
			}
          if (GameInformation.Energy < 0)
            {
                GameInformation.Energy = 0;
                energyStatus();
            }
            else if (battleController.Model.ActiveTurn)
            {
                yield return new WaitForEndOfFrame();
            }
		}
	}
    static public void energyStatus() {
        Status energyStatus = GameObject.FindGameObjectWithTag("Player_EnergyBar").GetComponent<Status>();
        energyStatus.changeStatusSize(GameInformation.Energy, GameInformation.MaxEnergy);
    }
	//public static Player Player{ get; set; }

    public BattleController battleController{ get; set; }
}
