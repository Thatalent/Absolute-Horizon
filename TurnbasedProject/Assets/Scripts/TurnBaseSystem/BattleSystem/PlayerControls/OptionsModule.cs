//Created by Jonathan Hudson for DoL 242. Github username Thatalent

using UnityEngine;
using System.Collections;

public class OptionsModule
{

	//TODO: Make lowEnergy compare magic and attack moves together, along with any possible moves.
	//TODO: Add ammo check to low value finding algorithms.

	private static int t;

	public enum UserMenuStatus { CENTER, RIGHT, LEFT, UP, DOWN, L_ITEMS, R_ITEMS, ABILITIES };
	public enum UserActionType { COMMANDS, REACTION, CHASING, CLASH, PARTNER }


	// Use this for initialization
	static public OptionsModule start(PlayerActions playerActions)
	{
		OptionsModule model = new OptionsModule(playerActions);
		return model;
	}

	private OptionsModule(PlayerActions actions)
	{
		Actions = actions;
		Moves[] allActions = actions.AllActions;
		Moves[] magicActions = actions.MagicActions;
		LoMana = int.MaxValue;
		LoAttackEnergy = int.MaxValue;
		LoMagicEnergy = int.MaxValue;
		CommandState = new Commands();
		State = new CenterBattleMenuState(this);
	}

	public void setValues(){

		Moves [] allMoves =battleController.Player.Actions.AllActions;
		for (int i =0; i <allMoves.Length; i++){
			allMoves[i].BattleController = battleController;
			allMoves[i].Player = battleController.Player;
		}
		LowestMoveCount= OptionsModule.lowMove(allMoves);
		Debug.LogWarning("Lowest Move count: "+LowestMoveCount);
		lowEnergy(allMoves);
		lowMana(battleController.Player.Actions.MagicActions);
	}

	public void executeCommands(){
		if(battleController.ActiveBattle){
			State.executeCommand(this);
		}
	}

	public void playerTurn(Moves playerMove)
	{
		playerMove.Player = battleController.Player;
		playerMove.BattleController = battleController;

		int m = battleController.Player.MoveCounter - playerMove.MoveCount;

		Debug.Log("Player Move Engery use :"+playerMove.Name);
		Debug.Log("Player Energy: "+battleController.Player.Energy);
		Debug.Log("Player Mana: "+battleController.Player.Mana);
		Debug.Log("Player Special Charage: "+GameInformation.SpecialCharge);
		Debug.LogWarning("Player Move Engery use :"+playerMove.EpUse);
		Debug.Log("Player Move Mana use :"+playerMove.MpUse);
		Debug.LogWarning("Player Move Count use :"+playerMove.MoveCount);
		Debug.LogWarning("Player MoveCounter use :"+battleController.Player.MoveCounter);

		if (playerMove.Player.Energy >= playerMove.EpUse && (m) >= 0 && playerMove.Player.Mana >= playerMove.MpUse && GameInformation.SpecialCharge >= playerMove.SpUse)
		{
			ActiveTurn = true;
			battleController.Player.MoveCounter = m;
			Debug.LogWarning("Player MoveCounter use :"+battleController.Player.MoveCounter);

			playerMove.resource();
			float hit = playerMove.accuracy();

			if (Random.value <= hit)
			{
				playerMove.move(battleController);
			}
		}
		else if (m < 0)
		{
			Debug.LogWarning("Wating because m is lower lower than 0");

			endTurn();
			return;
		}
		else if (ActiveTurn == true && playerMove.Player.Energy < playerMove.EpUse)
		{
			Debug.LogWarning("Wating because Energy is lower lowest Energy count");

			endTurn();
			return;
		}
		if (battleController.Player.MoveCounter < LowestMoveCount)
		{
			Debug.LogWarning("Player MoveCounter use :"+battleController.Player.MoveCounter);

			Debug.LogWarning("Wating because MoveCounter is lower lowest Move count");
			 endTurn();
			 return;
			//   turnWait();
		}
		if (playerMove.Player.Energy < LoAttackEnergy)
		{
			if (ActiveTurn)
			{
				Debug.LogWarning("Wating because Eneergy is loower than lowest count and turn is active");

				endTurn();
				return;
			}
			else
			{
				FloatingText.Show("Need More Energy :(", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, GameInformation.MoveWait, 0));
				return;
			}

			Debug.LogWarning("Wating because  Eneergy is loower than lowest count");

			//  endTurn();
			//   turnWait();
		}
		if (playerMove.Player.Mana < LoMana)
		{
			// EndTurn = true;
						Debug.LogWarning("Wating because MoveCounter is lower lowest Move count");

			 endTurn();
			 return;
			//   turnWait();
		}
		if (battleController.Player.MoveCounter <= 0)
		{
			// EndTurn = true;
			// turnWait();
						Debug.LogWarning("Wating because MoveCounter is lower lowest Move count");

			endTurn();
			return;
		}
	}

	public IEnumerator turnWait()
	{
		if (t == 0)
		{
			t = 1;
			Wait = true;
			ActiveTurn = false;
			Debug.LogWarning("Wait Start");
			yield return new WaitForSeconds(battleController.Player.MoveWait);
			Wait = false;
			FloatingText.Show("Ready!!!", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, 1f, 0));
			battleController.Player.MoveCounter = battleController.Player.MaxMoveCounter;
			Debug.LogWarning("Move reset to: "+ battleController.Player.MaxMoveCounter);
			t = 0;
		}
	}

	public void endTurn(){

        FloatingText.Show("Waiting . . .", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, battleController.Player.MoveWait, 0));

    	battleController.StartCoroutine(this.turnWait());
	}

	//Finds lowest move count in a group of moves

	public static int lowMove(Moves[] moves)
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
		int[] moveCounted = new int[moveCounts.Count];

		for (int i = 0; i < moveCounted.Length; i++)
		{
			moveCounted[i] = (int)moveCounts[i];
		}
		Solution.quickSort(moveCounted, 0, moveCounted.Length - 1);
		lowestMove = moveCounted[0];
		return lowestMove;
	}

	public void lowEnergy(Moves[] moves)
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

	public void lowMana(Moves[] moves)
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

	public int LoMana { get; set; }
	public int LoAttackEnergy { get; set; }
	public int LoMagicEnergy { get; set; }
	public bool ActiveTurn { get; set; }
	public OptionsModule Model { get; set; }

	public PlayerActions Actions { get; set; }

	//TODO: Danjamin make the setter call a method that call a method in the options view class to update the available options.
	public UserMenuStatus MenuOpened { get; set; }
	public UserActionType ActionType { get; set; }
	public Moves[] AvailableOptions
	{
		get
		{
			if ((int)MenuOpened > Actions.UnlockedActionMenus)
			{
				return Actions.getActions((int)MenuOpened);
			}
			else return null;
		}
	}
	public Commands CommandState { get; set; }

	public BattleController battleController { get; set; }

	public BattleState State { get; set; }

	public int LowestMoveCount { get; set; }

    public bool Wait { get; set; }

	public bool EndPlayerTurn{ get; set; }
}
