
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ReactionState : BattleState
    {

        //TODO: Reaction state must:
        /**  s
        * 1) Take in reaction command that is executed when input is succuessful
        * 2) Display images of commands to repersent what input should be pressed.
        *     this can be one at a time or all at once, or display what has been pressed.
        * 3) Record input based on execute moves. 
        *     (Should we use the individual execution functions or override the execute function)
        * 4) 
        * */

        public Action RectionCallback { get; set; }

        public Queue<string> CommandQueue { get; set; }

        public Queue<string> InputQueue { get; set; }
    }