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
        m = 0;

	
	}

	public static void attackMove(string aMove){
		Moves[] attacks = GameInformation.Attacks;
		switch (aMove) 
		{
		case "Stab":
			attacks[a]=new Stab();
			Debug.Log (attacks[a]);
			GameInformation.Attacks=attacks;
			Debug.Log (GameInformation.Attacks);
			a++;
			break;
		}
		if (a == 16)
			a = 0;
		//Options.loadMoves ();
	}
    public static void magicMove(string mMove)
    {
        Moves[] spells = GameInformation.Spells;
        switch (mMove)
        {
            case "Sparkles":
                spells[m] = new Sparkles();
                Debug.Log(spells[m]);
                GameInformation.Spells = spells;
                Debug.Log(GameInformation.Spells);
                m++;
                break;
        }
        if (m  == 16)
            m = 0;
        //Options.loadMoves();
    }
    // Update is called once per frame
    void Update () {
	
	}
	public static string[] AMoves{ get; set; }
	public static string[] MMoves{ get; set; }
	public static int A{ get; set; }
	public static int M{ get; set; }
}
