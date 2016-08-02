using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private static Moves[] attacks;
    private static Moves trigger;
    private static Moves[] spells;
    private static Moves[] specials;
    private static int[] move;
    private static int i;
    private static Moves playerMove;
    private enum UserChoiceStatus {SELECT_ACTION, SELECT_MOVE, INITIATE_MOVE, END_MOVE}; 
    //TODO: FINISH DIS


// Use this for initialization
void Start () {
		attacks=new Moves[16];
		trigger=null;
		spells=new Moves[16];
		specials=new Moves[5]; 
		move = new int[3];
        Wait = false;
		i= 0;
	}


	// Update is called once per frame
	void Update () {


        //Conditional Input for ending Player's Turn

        if (Input.GetButtonDown("cancel")||EndPlayerTurn && OptionsModule.ActiveTurn)
        {
            // OptionsModule.endPlayerTurn();
            EndPlayerTurn = false;
            FloatingText.Show("Waiting . . .", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, GameInformation.MoveWait, 0));

            StartCoroutine(OptionsModule.turnWait());
        }

        if (Input.GetButtonDown("Down"))
        {
            if (i == 1)
            {
                i = i - 1;
            }
        }

		for (int j=0; j<6; j++) {

			if(BattleController.EnemyMob[j]!=null){
				if (BattleController.EnemyMob[j].activeInHierarchy){
					BattleController.Enemy=BattleController.EnemyMob[j];
				}
			}
			else
				j++;
		}
        if (!ActiveEnemy && !Wait)
        {
            if (i == 0)
            {

                if (Input.GetButtonDown("attack"))
                {
                    move[i] = 1;
                    Debug.Log("Up");
                    i++;
                }
                if (Input.GetButtonDown("magic"))
                {
                    move[i] = 2;
                    Debug.Log("Down");
                    i++;
                }
                if (Input.GetButtonDown("special"))
                {
                    move[i] = 3;
                    i++;
                }
                if (Input.GetButtonDown("items"))
                {
                    move[i] = 4;
                    i++;
                }
                if (Input.GetButtonDown("Trigger"))
                {
                    OptionsModule.playerTurn(Trigger);
                }
                //  Input.ResetInputAxes();
            }
            if (i == 1)
            {
                if (Input.GetButton("attack") && Input.GetButtonDown("weapon1"))
                {
                    move[i] = 0;
                    Debug.Log("Attack");
                    i++;
                }
                if (Input.GetButton("magic") && Input.GetButtonDown("weapon1"))
                {
                    move[i] = 0;
                    i++;
                }
            }
            //Input.ResetInputAxes();

            if (i == 2)
            {
                OptionsModule.ActiveTurn = true;
                if (move[0] == 1)
                {
                    playerMove = GameInformation.Attacks[move[1]];
                    //Debug.Log (playerMove);
                    //BattleController.EnemyMob=GameObject.FindGameObjectsWithTag("Enemy");
                }
                else if (move[0] == 2)
                {
                    playerMove = GameInformation.Spells[move[1]];
                }
                else if (move[0] == 3)
                {
                    playerMove = GameInformation.Specials[move[1]];
                }
                else if (move[0] == 4)
                {
                    // playerMove = Items[move[1]];
                    //Create Battle Items array
                }
                // }

                //if (Input.GetButtonDown ("move")){
                if (playerMove != null)
                {
                    OptionsModule.playerTurn(playerMove);
                    playerMove = null;
                    i = 0;
                }
            }
        }
    }

    public static void loadMoves(){
        OptionsModule.start();
		Options.Attacks  = GameInformation.Attacks;
		Options.attacks = Attacks;
        LowestMoveCount= OptionsModule.lowMove(Attacks);
        OptionsModule.lowEnergy(Attacks, "attacks");
		Debug.Log (attacks[0]);
        Spells = GameInformation.Spells;
		spells  = GameInformation.Spells;
        Debug.Log(Spells[0]);
        OptionsModule.lowMove(Spells);
        OptionsModule.lowEnergy(Spells, "spells");
        OptionsModule.lowMana(Spells);
        specials  = GameInformation.Specials;
       // OptionsModule.lowMove(specials);
        trigger  = GameInformation.Trigger;
	}

	public static Moves[] Attacks{ get; set; }
	public static Moves[] Spells{ get; set; }	
	public static Moves[] Specials{ get; set; }
	public static Moves Trigger{ get; set; }
    public static bool ActiveEnemy { get; set; }
    public static bool Wait { get; set; }
    public static int LowestMoveCount { get; set; }
    public static bool EndPlayerTurn { get; set; }
}
