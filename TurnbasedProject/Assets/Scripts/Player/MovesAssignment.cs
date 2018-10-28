using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public class MovesAssignment : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	public static bool assignMove(string moveName){

		Type newMove = MovesAssignment.getNewMoveType(moveName);
        
		if(newMove != null){
			
			Moves move = (Moves)Activator.CreateInstance(newMove);
            
			GameInformation.Actions.loadActionMove(move);

			Debug.Log(GameInformation.Actions.AllActions);
			return true;
			
		}
		else{
			return false;
		}
	}

	public static Type getNewMoveType(string moveName){
		
		Type newMove = GameInformation.AllMoves[moveName];

		return newMove;

	}
}
