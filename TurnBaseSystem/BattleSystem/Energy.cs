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
		while(true) {
            yield return new WaitForSeconds(1);
			if (GameInformtion.Energy < GameInformtion.MaxEnergy) {
				GameInformtion.Energy = GameInformtion.Energy + GameInformtion.EnergyRate;
            //yield return new WaitForSeconds(10);
				Debug.Log(GameInformtion.Energy);
				if (GameInformtion.Energy > GameInformtion.MaxEnergy) {
					GameInformtion.Energy = GameInformtion.MaxEnergy;
                  //  yield return new WaitForSeconds(2f);
				}
			}
		}
	}
	//public static Player Player{ get; set; }
}
