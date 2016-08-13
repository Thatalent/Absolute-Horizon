using UnityEngine;
using System.Collections;

public class OptionsModule : MonoBehaviour {

    private static int t;


    // Use this for initialization
    static public void start () {
        LoMana = int.MaxValue;
        LoAttackEnergy = int.MaxValue;
        LoMagicEnergy = int.MaxValue;
    }
	
	// Update is called once per frame
	void Update () {
	}


    public static void playerTurn(Moves playerMove)
    {
        int m = GameInformtion.Player.MoveCounter - playerMove.MoveCount;
        // Debug.Log(GameInformtion.Energy);
        // Debug.Log(playerMove.EpUse);

        if (GameInformtion.Energy >= playerMove.EpUse && (m) >= 0 && GameInformtion.Mana >= playerMove.MpUse && GameInformtion.SpecialCharge >= playerMove.SpUse)
        {
            GameInformtion.Player.MoveCounter = m;
            //  Debug.Log(GameInformtion.Energy);
            playerMove.resource();
            float hit = playerMove.accuracy();
            if (Random.value <= hit)
            {
                playerMove.move();
            }
        }
        else if (m < 0)
        {
            Options.End = true;
        }
        else if (OptionsModule.ActiveTurn == true && GameInformtion.Energy < playerMove.EpUse)
        {
            Options.End = true;
        }
       if (GameInformtion.Player.MoveCounter < Options.LoMv)
        {
            Options.End = true;
          //  endPlayerTurn();
         //   turnWait();
        }
      if  (GameInformtion.Energy < OptionsModule.LoAttackEnergy )
        {
            Options.End = true;
            //  endPlayerTurn();
            //   turnWait();
        }
        if     (GameInformtion.Energy < OptionsModule.LoMagicEnergy | GameInformtion.Mana < OptionsModule.LoMana)
        {
            Options.End = true;
            //  endPlayerTurn();
            //   turnWait();
        }
        else if (GameInformtion.Player.MoveCounter <= 0)
        {
            Options.End=true;
            //turnWait();
           // endPlayerTurn();
        }
    }
  /*  public static void endPlayerTurn()
    {
        Options.ActiveTurn = false;
        GameInformtion.Player.MoveCounter = GameInformtion.MoveCounter;
    }*/
    public static IEnumerator turnWait()
    {
        if (t == 0)
        {
            t=1;
            Options.Wait = true;
            ActiveTurn = false;
            Debug.Log("Now Waiting.");
            yield return new WaitForSeconds(GameInformtion.MoveWait);
            Options.Wait = false;
            Debug.Log("Done Waiting.");
            GameInformtion.Player.MoveCounter = GameInformtion.MoveCounter;
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
        /*for(int i=0; i < moves.Length; i++)
        {
            if (moves[i] != null)
            {
                if (moves[i].MoveCount < lowestMove)
                {
                    lowestMove = moves[i].MoveCount;
                }
                else
                    continue;
            }
            else
                continue;
        }*/
        lowestMove = moveCounted[0];
        return lowestMove;
    }

    public static void lowEnergy( Moves [] moves, string m)
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
        switch (m)
        {
            case "attacks":
                if (LoAttackEnergy > energyCounted[0])
                {
                    LoAttackEnergy = energyCounted[0];
                }
                break;
            case "spells":
                if (LoMagicEnergy > energyCounted[0])
                {
                    LoMagicEnergy = energyCounted[0];
                }
                break;
            default: break;
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
}