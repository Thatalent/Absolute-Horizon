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
    private enum UserChoiceStatus { SELECT_ACTION, SELECT_MOVE, INITIATE_MOVE, END_MOVE}; 
    private enum UserActionStatus { ATTACK, MAGIC, SPECIAL, L_ITEMS, R_ITEMS, ABILITIES};
    private enum UserOptionStatus { FIRST, SECOND, THIRD, FOURTH, FIFTH, SIXTH, SEVENTH, EIGHTH, NINITH};
    //TODO: FINISH DIS


// Use this for initialization
void Start () {
		attacks=new Moves[9];
		trigger=null;
		spells=new Moves[9];
		specials=new Moves[5]; 
		move = new int[3];
        Wait = false;
        UserChoice = UserChoiceStatus.SELECT_ACTION;
    }


    // Update is called once per frame
    void Update () {

        if (BattleController.Battle == true)
        {
            //Conditional Input for ending Player's Turn

            if (Input.GetButtonDown("cancel") || EndPlayerTurn && OptionsModule.ActiveTurn)
            {
                EndPlayerTurn = false;
                FloatingText.Show("Waiting . . .", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, GameInformation.MoveWait, 0));

                StartCoroutine(OptionsModule.turnWait());
            }

            if (Input.GetButtonDown("Down"))
            {
                if (UserChoice == UserChoiceStatus.SELECT_MOVE)
                {
                    UserChoice = UserChoiceStatus.SELECT_ACTION;
                }
            }

            if (BattleController.Enemy == null || BattleController.Enemy.GetComponent<Enemy>().Health <= 0 || Input.GetButtonDown("nextEnemy"))
            {
                BattleController.Enemy = getNextEnemy(BattleController.EnemyIndex);
                Debug.Log("next Enemy selected at index: " + BattleController.EnemyIndex);
            }

            if (Input.GetButtonDown("previousEnemy"))
            {
                BattleController.Enemy = getPreviousEnemy(BattleController.EnemyIndex);
                Debug.Log("previous Enemy selected at index: " + BattleController.EnemyIndex);
            }

            if (!ActiveEnemy && !Wait)
            {
                if (UserChoice.Equals(UserChoiceStatus.SELECT_ACTION))
                {

                    if (Input.GetButtonDown("attack"))
                    {
                        move[0] = (int)UserActionStatus.ATTACK;
                        Debug.Log("Up");
                        UserChoice = UserChoiceStatus.SELECT_MOVE;
                    }
                    if (Input.GetButtonDown("magic"))
                    {
                        move[0] = (int)UserActionStatus.MAGIC;
                        Debug.Log("Down");
                        UserChoice = UserChoiceStatus.SELECT_MOVE;
                    }
                    if (Input.GetButtonDown("special"))
                    {
                        move[0] = (int)UserActionStatus.SPECIAL;
                        UserChoice = UserChoiceStatus.SELECT_MOVE;
                    }
                    if (Input.GetButtonDown("items"))
                    {
                        move[0] = (int)UserActionStatus.L_ITEMS;
                        UserChoice = UserChoiceStatus.SELECT_MOVE;
                    }
                    /*              Waiting to create needed controls in input section. Currently have not implemented abilities or items

                                    if(Input.GetButtonDown("right_items"))
                                    {
                                        move[0] = (int)UserActionStatus.R_ITEMS;
                                        UserChoice = UserChoiceStatus.SELECT_MOVE;
                                    }
                                    if (Input.GetButtonDown("ability1"))
                                    {
                                        move[0] = (int)UserActionStatus.ABILITIES;
                                        move[1] = (int)UserOptionStatus.FIRST;
                                    }
                                    if (Input.GetButtonDown("ability2"))
                                    {
                                        move[0] = (int)UserActionStatus.ABILITIES;
                                        move[1] = (int)UserOptionStatus.SECOND;
                                    }
                                    if (Input.GetButtonDown("ability3"))
                                    {
                                        move[0] = (int)UserActionStatus.ABILITIES;
                                        move[1] = (int)UserOptionStatus.THIRD;
                                    }
                                    if (Input.GetButtonDown("ability4"))
                                    {
                                        move[0] = (int)UserActionStatus.ABILITIES;
                                        move[1] = (int)UserOptionStatus.FOURTH;
                                    } */
                }
                if (UserChoice.Equals(UserChoiceStatus.SELECT_MOVE))
                {
                    if (Input.GetButton("attack") && Input.GetButtonDown("weapon1"))
                    {
                        move[1] = (int)UserOptionStatus.FIRST;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("attack") && Input.GetButtonDown("weapon2"))
                    {
                        move[1] = (int)UserOptionStatus.SECOND;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("attack") && Input.GetButtonDown("weapon3"))
                    {
                        move[1] = (int)UserOptionStatus.THIRD;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("magic") && Input.GetButtonDown("weapon1"))
                    {
                        move[1] = (int)UserOptionStatus.FOURTH;
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("magic") && Input.GetButtonDown("weapon2"))
                    {
                        move[1] = (int)UserOptionStatus.FIFTH;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("magic") && Input.GetButtonDown("weapon3"))
                    {
                        move[1] = (int)UserOptionStatus.SIXTH;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("special") && Input.GetButtonDown("weapon1"))
                    {
                        move[1] = (int)UserOptionStatus.SEVENTH;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("special") && Input.GetButtonDown("weapon2"))
                    {
                        move[1] = (int)UserOptionStatus.EIGHTH;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                    if (Input.GetButton("special") && Input.GetButtonDown("weapon3"))
                    {
                        move[1] = (int)UserOptionStatus.NINITH;
                        Debug.Log("Attack");
                        UserChoice = UserChoiceStatus.INITIATE_MOVE;
                    }
                }

                if (UserChoice.Equals(UserChoiceStatus.SELECT_ACTION) || UserChoice.Equals(UserChoiceStatus.SELECT_MOVE))
                {
                    if (Input.GetButtonDown("Trigger"))
                    {
                        OptionsModule.playerTurn(Trigger);
                    }
                }

                if (UserChoice.Equals(UserChoiceStatus.INITIATE_MOVE))
                {
                    OptionsModule.ActiveTurn = true;
                    if (move[0] == (int)UserActionStatus.ATTACK)
                    {
                        playerMove = GameInformation.Attacks[move[1]];
                    }
                    else if (move[0] == (int)UserActionStatus.MAGIC)
                    {
                        playerMove = GameInformation.Spells[move[1]];
                    }
                    else if (move[0] == (int)UserActionStatus.SPECIAL)
                    {
                        playerMove = GameInformation.Specials[move[1]];
                    }
                    else if (move[0] == (int)UserActionStatus.L_ITEMS)
                    {
                        // playerMove = Items[move[1]];
                        //Create Battle Items array
                    }
                    else if (move[0] == (int)UserActionStatus.R_ITEMS)
                    {
                        // playerMove = R_Items[move[1]];
                    }
                    if (playerMove != null)
                    {
                        OptionsModule.playerTurn(playerMove);
                        playerMove = null;
                        UserChoice = UserChoiceStatus.SELECT_ACTION;
                    }
                    else
                    {
                        UserChoice = UserChoiceStatus.SELECT_ACTION;
                    }
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

    /// <summary>
    /// Gets the next active enemy in BattleController.Enemymob that has health above 0 by incrementing the index of enemy mob by one.
    /// </summary>
    /// <param name="enemyIndex"></param>
    /// <returns></returns>
    public static GameObject getNextEnemy(int enemyIndex)
    {
        if (++enemyIndex >= BattleController.EnemyMob.Length)
        {
            enemyIndex = 0;
        }
        GameObject possibleEnemy = BattleController.EnemyMob[enemyIndex];

      if (possibleEnemy == null || !BattleController.EnemyMob[enemyIndex].activeInHierarchy || possibleEnemy.GetComponent<Enemy>().Health <= 0)
            {

            possibleEnemy = getNextEnemy(enemyIndex);
            }
      else
        {
            BattleController.EnemyIndex = enemyIndex;
        }
        return possibleEnemy;
    }

    /// <summary>
    /// Gets the previous active enemy in BattleController.Enemymob that has health above 0 by decrementing the index by one.
    /// </summary>
    /// <param name="enemyIndex"></param>
    /// <returns></returns>
    public static GameObject getPreviousEnemy(int enemyIndex)
    {
        if(--enemyIndex < 0)
        {
            enemyIndex = BattleController.EnemyMob.Length - 1;
        }
        GameObject possibleEnemy = BattleController.EnemyMob[enemyIndex];

        if (possibleEnemy == null || !BattleController.EnemyMob[enemyIndex].activeInHierarchy || possibleEnemy.GetComponent<Enemy>().Health <= 0)
        {

            possibleEnemy = getPreviousEnemy(enemyIndex);
        }
        else
        {
            BattleController.EnemyIndex = enemyIndex;
        }
        return possibleEnemy;
    }

    public static Moves[] Attacks{ get; set; }
	public static Moves[] Spells{ get; set; }	
	public static Moves[] Specials{ get; set; }
	public static Moves Trigger{ get; set; }
    public static Moves[] R_Items { get; set; }
    public static Moves[] L_Items { get; set; }
    public static Moves[] Abilities { get; set; }
    public static bool ActiveEnemy { get; set; }
    public static bool Wait { get; set; }
    public static int LowestMoveCount { get; set; }
    public static bool EndPlayerTurn { get; set; }
    private static UserChoiceStatus UserChoice { get; set; }
}
