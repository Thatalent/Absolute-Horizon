using UnityEngine;

public abstract class BattleState : ControllerState
{

    public void executeCommand(OptionsModule module){
        
        Commands commands = module.CommandState;
        
        if(commands.StartButton){
            this.executeStart(module);
        }
        else if(commands.SelectButton){
            this.executeSelect(module);
        }
        else if(commands.RbButton){
            this.executeRBumper(module);
        }
        else if(commands.LbButton){
            this.executeLBumper(module);
        }
        else if(commands.AButton || commands.BButton || commands.XButton || commands.YButton){
            this.executeABXYButtons(module);
        }
        else if(commands.LCtrlButton){
            this.executeLCtrlStick(module);
        }
        else if(commands.RCtrlButton){
            this.executeR_CtrlStick(module);
        }
        else if(commands.LtButton){
            this.executeLTrigger(module);
        }
        else if(commands.RtButton){
             this.executeRTrigger(module);
        }
    }

    public virtual void executeABXYButtons(OptionsModule module){

        Commands commands = module.CommandState;

        if(commands.AButton){
            this.executeAButton(module);
        }if(commands.BButton){
            this.executeBButton(module);
        }if(commands.XButton){
            this.executeXButton(module);
        }if(commands.YButton){
            this.executeYButton(module);
        }
    }
    public abstract void executeAButton(OptionsModule module);

    public abstract void executeBButton(OptionsModule module);
    public abstract void executeRBumper(OptionsModule module);

    public abstract void executeLBumper(OptionsModule module);

    public abstract void executeLCtrlStick(OptionsModule module);

    public abstract void executeLTrigger(OptionsModule module);

    public abstract void executeRTrigger(OptionsModule module);
    public abstract void executeR_CtrlStick(OptionsModule module);

    public abstract void executeSelect(OptionsModule module);
    public abstract void executeStart(OptionsModule module);

    public abstract void executeXButton(OptionsModule module);
    public abstract void executeYButton(OptionsModule module);

    protected virtual void setFieldsOnMove(BattleController battleController, Moves move){
        move.BattleController = battleController;
		move.Player = battleController.Player;
    }
}