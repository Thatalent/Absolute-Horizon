using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands
{

    public Commands(){
        LeftStick = new Axis_2d();
        RightStick = new Axis_2d();
    }

	public bool XButton { get; set; }
    public bool YButton { get; set; }
    public bool AButton { get; set; }
    public bool BButton { get; set; }
    public bool LCtrlButton { get; set; }
    public bool RCtrlButton { get; set; }
    public bool StartButton { get; set; }
    public bool SelectButton { get; set; }
    public bool LbButton { get; set; }
    public bool RbButton { get; set; }
    public bool RtButton { get; set; }
    public bool LtButton { get; set; }
    public Axis_2d LeftStick { get; set; }
    public Axis_2d RightStick {get; set; }
}

