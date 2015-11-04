using UnityEngine;
using System.Collections;

public class OptionsModule : MonoBehaviour {

    private static bool activeTurn;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ActiveTurn = Options.ActiveTurn;
	}
    public static void playerTurn(Moves playerMove)
    {
       // Debug.Log(GameInformtion.Energy);
       // Debug.Log(playerMove.EpUse);

        if (GameInformtion.Energy >= playerMove.EpUse)
        {
            GameInformtion.Energy = GameInformtion.Energy - playerMove.EpUse;
          //  Debug.Log(GameInformtion.Energy);
            float hit = playerMove.accuracy();
            if (Random.value <= hit)
            {
                playerMove.move();
            }
        }
    }
    public static bool ActiveTurn { get; set; }
}