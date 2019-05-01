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
		LowestMoveCount= OptionsModule.lowMove(battleController.Player.Actions.AllActions);
		lowEnergy(battleController.Player.Actions.AllActions);
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

		if (playerMove.Player.Energy >= playerMove.EpUse && (m) >= 0 && playerMove.Player.Mana >= playerMove.MpUse && GameInformation.SpecialCharge >= playerMove.SpUse)
		{
			ActiveTurn = true;
			battleController.Player.MoveCounter = m;
			playerMove.resource();
			float hit = playerMove.accuracy();

			if (Random.value <= hit)
			{
				playerMove.move(battleController);
			}
		}
		else if (m < 0)
		{
			EndPlayerTurn = true;
		}
		else if (ActiveTurn == true && playerMove.Player.Energy < playerMove.EpUse)
		{
			EndPlayerTurn = true;
		}
		if (battleController.Player.MoveCounter < LowestMoveCount)
		{
			EndPlayerTurn = true;
			//  endPlayerTurn();
			//   turnWait();
		}
		if (playerMove.Player.Energy < LoAttackEnergy)
		{
			if (ActiveTurn)
			{
				EndPlayerTurn = true;
			}
			else
			{
				FloatingText.Show("Need More Energy :(", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, GameInformation.MoveWait, 0));
			}


			//  endPlayerTurn();
			//   turnWait();
		}
		if (playerMove.Player.Mana < LoMana)
		{
			EndPlayerTurn = true;
			//  endPlayerTurn();
			//   turnWait();
		}
		else if (battleController.Player.MoveCounter <= 0)
		{
			EndPlayerTurn = true;
			// turnWait();
			// endPlayerTurn();
		}
	}

	public IEnumerator turnWait()
	{
		if (t == 0)
		{
			t = 1;
			Wait = true;
			ActiveTurn = false;
			yield return new WaitForSeconds(battleController.Player.MoveWait);
			Wait = false;
			FloatingText.Show("Ready!!!", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, 1f, 0));
			battleController.Player.MoveCounter = battleController.Player.MoveCounter;
			t = 0;
		}
	}

	public void endTurn(){

		EndPlayerTurn = false;
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
