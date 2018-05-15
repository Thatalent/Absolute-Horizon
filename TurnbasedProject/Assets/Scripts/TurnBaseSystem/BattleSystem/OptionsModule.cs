using UnityEngine;
using System.Collections;

public class OptionsModule {

	//TODO: Make lowEnergy compare magic and attack moves together, along with any possible moves.
	//TODO: Add ammo check to low value finding algorithms.

    private static int t;


    // Use this for initialization
	static public void start (PlayerActions playerActions) {
        LoMana = int.MaxValue;
        LoAttackEnergy = int.MaxValue;
        LoMagicEnergy = int.MaxValue;
		Model = new OptionsModule(playerActions);
    }
    
	private OptionsModule(PlayerActions actions){
		Actions = actions;
		Moves[] allActions = actions.AllActions;
		Moves[] magicActions = actions.MagicActions;
	}

    public static void playerTurn(Moves playerMove)
    {
        int m = GameInformation.Player.MoveCounter - playerMove.MoveCount;

        if (GameInformation.Energy >= playerMove.EpUse && (m) >= 0 && GameInformation.Mana >= playerMove.MpUse && GameInformation.SpecialCharge >= playerMove.SpUse)
        {
            GameInformation.Player.MoveCounter = m;
            playerMove.resource();
            float hit = playerMove.accuracy();

            if (Random.value <= hit)
            {
                playerMove.move();
            }
        }
        else if (m < 0)
        {
            Options.EndPlayerTurn = true;
        }
        else if (OptionsModule.ActiveTurn == true && GameInformation.Energy < playerMove.EpUse)
        {
            Options.EndPlayerTurn = true;
        }
       if (GameInformation.Player.MoveCounter < Options.LowestMoveCount)
        {
            Options.EndPlayerTurn = true;
          //  endPlayerTurn();
         //   turnWait();
        }
      if  (GameInformation.Energy < OptionsModule.LoAttackEnergy )
        {
            if (OptionsModule.ActiveTurn)
            {
                Options.EndPlayerTurn = true;
            } else
            {
                FloatingText.Show("Need More Energy :(", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, GameInformation.MoveWait, 0));
            }


            //  endPlayerTurn();
            //   turnWait();
        }
        if     (GameInformation.Mana < OptionsModule.LoMana)
        {
            Options.EndPlayerTurn = true;
            //  endPlayerTurn();
            //   turnWait();
        }
        else if (GameInformation.Player.MoveCounter <= 0)
        {
            Options.EndPlayerTurn=true;
            //turnWait();
           // endPlayerTurn();
        }
    }

    public static IEnumerator turnWait()
    {
        if (t == 0)
        {
            t=1;
            Options.Wait = true;
            ActiveTurn = false;
            yield return new WaitForSeconds(GameInformation.MoveWait);
            Options.Wait = false;
            FloatingText.Show("Ready!!!", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, 1f, 0));
            GameInformation.Player.MoveCounter = GameInformation.MoveCounter;
            t = 0;
        }
    }

    //Finds lowest move count in a group of moves

    public static int lowMove(Moves [] moves)
    {
        int lowestMove = int.MaxValue;
        ArrayList moveCounts = new ArrayList();
        for (int i = 0; i < moves.Length; i++)
        {
            if (moves[i] != null)
            {
                moveCounts.Add(moves[i].MoveCount);
            }
        }
        int[] moveCounted =  new int [moveCounts.Count];
        
        for (int i = 0; i < moveCounted.Length; i++)
        {
            moveCounted[i] = (int)moveCounts[i];
        }
        Solution.quickSort(moveCounted, 0, moveCounted.Length-1);
        lowestMove = moveCounted[0];
        return lowestMove;
    }

    public static void lowEnergy( Moves [] moves)
    {

        ArrayList energyCounts = new ArrayList();
        for (int i = 0; i < moves.Length; i++)
        {
            if (moves[i] != null)
            {
                energyCounts.Add(moves[i].EpUse);
            }
        }
        int[] energyCounted = new int[energyCounts.Count];

        for (int i = 0; i < energyCounted.Length; i++)
        {
            energyCounted[i] = (int)energyCounts[i];
        }
        Solution.quickSort(energyCounted, 0, energyCounted.Length - 1);
  
        if (LoAttackEnergy > energyCounted[0])
        {
            LoAttackEnergy = energyCounted[0];
        }          
    }

    public static void lowMana(Moves[] moves)
    {

        ArrayList manaCounts = new ArrayList();
        for (int i = 0; i < moves.Length; i++)
        {
            if (moves[i] != null)
            {
                manaCounts.Add(moves[i].MpUse);
            }
        }
        int[] manaCounted = new int[manaCounts.Count];

        for (int i = 0; i < manaCounted.Length; i++)
        {
            manaCounted[i] = (int)manaCounts[i];
        }
        Solution.quickSort(manaCounted, 0, manaCounted.Length - 1);
        if (LoMana > manaCounted[0])
        {
            LoMana = manaCounted[0];
        }
    }
    public static int LoMana { get; set; }
    public static int LoAttackEnergy { get; set; }
    public static int LoMagicEnergy { get; set; }
    public static bool ActiveTurn { get; set; }
	private PlayerActions Actions { get; set; }
	public static OptionsModule Model { get; set; }
}