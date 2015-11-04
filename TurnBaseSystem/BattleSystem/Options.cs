﻿using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad(transform.gameObject);
	}

	private static Moves[]attacks;
	private static Moves trigger;
	private  static Moves[]spells;
	private static Moves[]specials;
	private static  int[] move;
	private static  int i;
	private static  Moves playerMove;
    private static bool activeTurn;
    private static bool activeEnemy;

	// Use this for initialization
	void Start () {
		attacks=new Moves[16];
		trigger=null;
		spells=new Moves[16];
		specials=new Moves[5]; 
		move = new int[3];
		i= 0;
	}


	// Update is called once per frame
	void Update () {

        //Conditional Input for ending Player's Turn
        if (ActiveTurn && Input.GetButtonDown("cancel"))
        {

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
        if (!ActiveEnemy)
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
            }
            if (i == 1)
            {
                if (Input.GetButtonDown("attack") && Input.GetButton("weapon1"))
                {
                    move[i] = 0;
                    Debug.Log("Attack");
                    i++;
                }
                if (Input.GetButtonDown("attack") && Input.GetButton("weapon2"))
                {
                    move[i] = 1;
                    i++;
                }
            }

            if (i == 2)
            {
                ActiveTurn = true;
                if (move[0] == 1)
                {
                    playerMove = Attacks[move[1]];
                    //Debug.Log (playerMove);
                    //BattleController.EnemyMob=GameObject.FindGameObjectsWithTag("Enemy");
                }
                else if (move[0] == 2)
                {
                    playerMove = Spells[move[1]];
                }
                else if (move[0] == 3)
                {
                    playerMove = Specials[move[1]];
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
		Options.Attacks  = GameInformtion.Attacks;
		Options.attacks = Attacks;

		Debug.Log (attacks[0]);
		spells  = GameInformtion.Spells;
		specials  = GameInformtion.Specials;
		trigger  = GameInformtion.Trigger;
	}

	public static Moves[] Attacks{ get; set; }
	public static Moves[] Spells{ get; set; }	
	public static Moves[] Specials{ get; set; }
	public static Moves Trigger{ get; set; }
    public static bool ActiveTurn { get; set; }
    public static bool ActiveEnemy { get; set; }
}
