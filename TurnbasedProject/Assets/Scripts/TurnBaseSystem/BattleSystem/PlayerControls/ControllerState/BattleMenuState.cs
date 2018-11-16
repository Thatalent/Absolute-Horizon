using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleMenuState : BattleState {

	public BattleMenuState(OptionsModule module){
        Menu = module.Actions.getActions(menuNumber);
    }

	protected Moves[] Menu { get; set; }

	protected int menuNumber;
	protected enum ActionIndex { Y, X, A }

	public override void executeAButton(OptionsModule module)
    {
        if(module.Wait){
            return;
        }
		Moves move = Menu[(int)ActionIndex.A];
		setFieldsOnMove(module.battleController, move);
        module.playerTurn(move);
    }
	public override void executeXButton(OptionsModule module)
    {
        if(module.Wait){
            return;
        }
		Moves move = Menu[(int)ActionIndex.X];
		setFieldsOnMove(module.battleController, move);
        module.playerTurn(move);
    }
	public override void executeYButton(OptionsModule module)
    {
        Debug.LogWarning("Deciding to start move");
        if(module.Wait){
            Debug.LogWarning("Waiting for release!!!");
            return;
        }
    
		Moves move = Menu[(int)ActionIndex.Y];
		setFieldsOnMove(module.battleController, move);
        module.playerTurn(move);
    }


    public override void executeSelect(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }

    public override void executeStart(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }

    public override void executeR_CtrlStick(OptionsModule module)
    {
        
    }
}
