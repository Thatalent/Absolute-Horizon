using System;
using UnityEngine;

public class RightBattleMenuState : BattleMenuState {


    public RightBattleMenuState(OptionsModule module) : base(module)
    {
    }

    protected new int  menuNumber = 1;

       public override void executeLCtrlStick(OptionsModule module)
    {
        Axis_2d commands = module.CommandState.LeftStick;
        if (commands.Y_Axis != 0.0f && commands.X_Axis != 0.0f){
            float y =  commands.Y_Axis;
            float x =  commands.X_Axis;

            if(Math.Abs(y) < Math.Abs(x)){
                if(y > 0){
                    module.State = new UpBattleMenuState(module);
                }else{
                    module.State = new DownBattleMenuState(module);

                }
            }
            else {
               if(x < 0){
                    module.State = new LeftBattleMenuState(module);
                }
            }
        }
		else{
			module.State = new CenterBattleMenuState(module);
		}  
    }

    public override void executeBButton(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }

    public override void executeLBumper(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }

    public override void executeLTrigger(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }

    public override void executeRBumper(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }

    public override void executeRTrigger(OptionsModule module)
    {
        throw new System.NotImplementedException();
    }
}
