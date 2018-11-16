using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private static int[] move;
    private static Moves playerMove;
	public enum UserOptionStatus { FIRST, SECOND, THIRD, FOURTH, FIFTH, SIXTH, SEVENTH, EIGHTH, NINITH};
    //TODO: Add intergration with options GUI functionality


// Use this for initialization
void Start () {

    }


    // Update is called once per frame
    void Update () {

        if(Input.anyKey){

            Model.CommandState.XButton = Input.GetButtonDown("X_button");
            Model.CommandState.YButton = Input.GetButtonDown("Y_button");
            Model.CommandState.AButton = Input.GetButtonDown("A_button");
            Model.CommandState.BButton = Input.GetButtonDown("B_button");
            Model.CommandState.LCtrlButton = Input.GetButtonDown("L_Ctrl_button");
            Model.CommandState.RCtrlButton = Input.GetButtonDown("R_Ctrl_button");
            Model.CommandState.StartButton = Input.GetButtonDown("Start_button");
            Model.CommandState.SelectButton = Input.GetButtonDown("Select_button");
            Model.CommandState.LbButton = Input.GetButtonDown("Lb_button");
            Model.CommandState.RbButton = Input.GetButtonDown("Rb_button");
            Model.CommandState.RtButton = Input.GetButtonDown("Rt_button");
            Model.CommandState.LtButton = Input.GetButtonDown("Lt_button");
            Model.CommandState.LeftStick.X_Axis = Input.GetAxis("Left_Stick_Y");
            Model.CommandState.LeftStick.Y_Axis = Input.GetAxis("Left_Stick_X");
            Model.CommandState.RightStick.X_Axis = Input.GetAxis("Right_Stick_X");
            Model.CommandState.RightStick.Y_Axis = Input.GetAxis("Right_Stick_Y");

            Model.executeCommands();
        }

//         if (battleController.ActiveBattle == true)
//         {
//             //Conditional Input for ending Player's Turn

// 			if (Input.GetButtonDown("cancel") || EndPlayerTurn && OptionsModule.ActiveTurn && OptionsModule.Model.ActionType == OptionsModule.UserActionType.COMMANDS)
//             {
//                 EndPlayerTurn = false;
//                 FloatingText.Show("Waiting . . .", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, GameInformation.MoveWait, 0));

//                 StartCoroutine(OptionsModule.turnWait());
//             }

//             if (battleController.Enemy == null || battleController.Enemy.GetComponent<Enemy>().Health <= 0 || Input.GetButtonDown("nextEnemy"))
//             {
//                 battleController.Enemy = getNextEnemy(battleController.EnemyIndex);
//                 Debug.Log("next Enemy selected at index: " + battleController.EnemyIndex);
//             }

//             if (Input.GetButtonDown("previousEnemy"))
//             {
                // battleController.Enemy = battleController.getPreviousEnemy(battleController.EnemyIndex);
//                 Debug.Log("previous Enemy selected at index: " + battleController.EnemyIndex);
//             }

// 			if (!ActiveEnemy && !Wait && Model.ActionType == OptionsModule.UserActionType.COMMANDS)
//             {
//                 if (Input.GetButtonDown("RightButton"))
//                 {
//                     Model.MenuOpened = OptionsModule.UserMenuStatus.RIGHT;
//                 }
//                 else if (Input.GetButtonDown("LeftButton"))
//                 {
//                     Model.MenuOpened = OptionsModule.UserMenuStatus.LEFT;
//                 }
//                 else if (Input.GetButtonDown("UpButton"))
//                 {
//                     Model.MenuOpened = OptionsModule.UserMenuStatus.UP;
//                 }
//                 else if(Input.GetButtonDown("DownButton")){
//                     Model.MenuOpened = OptionsModule.UserMenuStatus.DOWN;
//                 }
//                 else{
//                     Model.MenuOpened = OptionsModule.UserMenuStatus.CENTER;
//                 }

//                 // if (Input.GetButtonDown("items"))
//                 // {
//                 //     Model.MenuOpened = OptionsModule.UserMenuStatus.L_ITEMS;
//                 // }
// /*              Waiting to create needed controls in input section. Currently have not implemented abilities or items

//                 if(Input.GetButtonDown("right_items"))
//                 {
//                    Model.MenuOpened = OptionsModule.UserMenuStatus.L_ITEMS;
//                 }
//                 if (Input.GetButtonDown("ability1"))
//                 {
//                     move[0] = (int)UserActionStatus.ABILITIES;
//                     move[1] = (int)UserOptionStatus.FIRST;
//                 }
//                 if (Input.GetButtonDown("ability2"))
//                 {
//                     move[0] = (int)UserActionStatus.ABILITIES;
//                     move[1] = (int)UserOptionStatus.SECOND;
//                 }
//                 if (Input.GetButtonDown("ability3"))
//                 {
//                     move[0] = (int)UserActionStatus.ABILITIES;
//                     move[1] = (int)UserOptionStatus.THIRD;
//                 }
//                 if (Input.GetButtonDown("ability4"))
//                 {
//                     move[0] = (int)UserActionStatus.ABILITIES;
//                     move[1] = (int)UserOptionStatus.FOURTH;
//                 } */
              
//                     if (Input.GetButton("attack") && Input.GetButtonDown("weapon1"))
//                     {
//                         move[1] = (int)UserOptionStatus.FIRST;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("attack") && Input.GetButtonDown("weapon2"))
//                     {
//                         move[1] = (int)UserOptionStatus.SECOND;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("attack") && Input.GetButtonDown("weapon3"))
//                     {
//                         move[1] = (int)UserOptionStatus.THIRD;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("magic") && Input.GetButtonDown("weapon1"))
//                     {
//                         move[1] = (int)UserOptionStatus.FOURTH;
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("magic") && Input.GetButtonDown("weapon2"))
//                     {
//                         move[1] = (int)UserOptionStatus.FIFTH;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("magic") && Input.GetButtonDown("weapon3"))
//                     {
//                         move[1] = (int)UserOptionStatus.SIXTH;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("special") && Input.GetButtonDown("weapon1"))
//                     {
//                         move[1] = (int)UserOptionStatus.SEVENTH;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("special") && Input.GetButtonDown("weapon2"))
//                     {
//                         move[1] = (int)UserOptionStatus.EIGHTH;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
//                     if (Input.GetButton("special") && Input.GetButtonDown("weapon3"))
//                     {
//                         move[1] = (int)UserOptionStatus.NINITH;
//                         Debug.Log("Attack");
//                         UserChoice = UserChoiceStatus.INITIATE_MOVE;
//                     }
                
//                 if (Input.GetButtonDown("Trigger"))
//                 {
//                     Model.useTriggerMove();
//                 }

//                     OptionsModule.ActiveTurn = true;
//                     if (move[0] == (int)UserMenuStatus.ATTACK)
//                     {
//                         playerMove = GameInformation.Attacks[move[1]];
//                     }
//                     else if (move[0] == (int)UserMenuStatus.MAGIC)
//                     {
//                         playerMove = GameInformation.Spells[move[1]];
//                     }
//                     else if (move[0] == (int)UserMenuStatus.SPECIAL)
//                     {
//                         playerMove = GameInformation.Specials[move[1]];
//                     }
//                     else if (move[0] == (int)UserMenuStatus.L_ITEMS)
//                     {
//                         // playerMove = Items[move[1]];
//                         //Create Battle Items array
//                     }
//                     else if (move[0] == (int)UserMenuStatus.R_ITEMS)
//                     {
//                         // playerMove = R_Items[move[1]];
//                     }
//                     if (playerMove != null)
//                     {
//                         OptionsModule.playerTurn(playerMove);
//                         playerMove = null;
//                         UserChoice = UserChoiceStatus.SELECT_ACTION;
//                     }
//                     else
//                     {
//                         UserChoice = UserChoiceStatus.SELECT_ACTION;
//                     }
//             }
// 			if(Model.ActionType == OptionsModule.UserActionType.REACTION)
//             {

//             }
// 			if (Model.ActionType == OptionsModule.UserActionType.CHASING)
//             {

//             }
// 			if (Model.ActionType == OptionsModule.UserActionType.CLASH)
//             {

//             }
// 			if (Model.ActionType == OptionsModule.UserActionType.PARTNER)
//             {

//             }
//         }
    }

    public static void loadMoves(){
        Model.setValues();
	}

    public Moves[] R_Items { get; set; }
    public Moves[] L_Items { get; set; }
    public Moves[] Abilities { get; set; }
    public static BattleController battleController{ get; set; }
	public  bool ActiveEnemy { get{ return battleController.ActiveEnemy; } }
    public bool EndPlayerTurn { get; set; }
	public static OptionsModule Model { get; set; }
}
