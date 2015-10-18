using UnityEngine;
using System.Collections;

public class MovesAssignment : MonoBehaviour {

	private static string[] aMoves=new string[16];
	private static string[] mMoves=new string[16];
	private static int a;
	private static int m;


	// Use this for initialization
	void Start () {
		a = 0;

	
	}

	public static void attackMove(string aMove){
		Moves[] attacks = GameInformtion.attacks;
		switch (aMove) 
		{
		case "Stab":
			attacks[a]=new Stab();
			Debug.Log (attacks[a]);
			GameInformtion.Attacks=attacks;
			Debug.Log (GameInformtion.Attacks);
			a++;
			break;
		}
		if (a == 16)
			a = 0;
		Options.loadMoves ();
	}
	// Update is called once per frame
	void Update () {
	
	}
	public static string[] AMoves{ get; set; }
	public static string[] MMoves{ get; set; }
	public static int A{ get; set; }
	public static int M{ get; set; }
}
