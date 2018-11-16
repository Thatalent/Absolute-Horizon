using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	//private static Player player;

	// Use this for initialization
	void Start () {
        //Player = GameInformtion.data ();
        battleController = GameObject.Find("Player-Character").GetComponent<BattleController>();
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
			if (battleController.Player.Energy < battleController.Player.MaxEnergy & !battleController.Model.ActiveTurn) {
				battleController.Player.Energy = battleController.Player.Energy + battleController.Player.EnergyRate;

                energyStatus();
            //yield return new WaitForSeconds(10);
				Debug.Log("New PLayer Energy: "+battleController.Player.Energy);
				if (battleController.Player.Energy > battleController.Player.MaxEnergy) {
                    Debug.LogWarning("JK New PLayer Energy is: "+battleController.Player.Energy);

					battleController.Player.Energy = battleController.Player.MaxEnergy;
                    energyStatus();
                  //  yield return new WaitForSeconds(2f);
				}
			}
          if (battleController.Player.Energy < 0)
            {
                battleController.Player.Energy = 0;
                energyStatus();
            }
            else if (battleController.Model.ActiveTurn)
            {
                yield return new WaitForEndOfFrame();
            }
		}
	}
    public void energyStatus() {
        Status energyStatus = GameObject.FindGameObjectWithTag("Player_EnergyBar").GetComponent<Status>();
        energyStatus.changeStatusSize(battleController.Player.Energy, battleController.Player.MaxEnergy);
    }
	//public static Player Player{ get; set; }

    public BattleController battleController{ get; set; }
}
