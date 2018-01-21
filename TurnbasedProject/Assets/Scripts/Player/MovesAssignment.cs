using UnityEngine;
using System.Collections;

public class MovesAssignment : MonoBehaviour {

	private static string[] aMoves=new string[9];
	private static string[] mMoves=new string[9];
	private static int a;
	private static int m;
    private static int s;

	// Use this for initialization
	void Start () {
		a = 0;
        m = 0;
        s = 0;
	
	}

	public static void attackMove(string aMove){
		Moves[] attacks = GameInformation.Attacks;
		switch (aMove) 
		{
		    case "Stab":
			    attacks[a]=new Stab();
			    GameInformation.Attacks=attacks;
			    a++;
			    break;
            case "DualStrike":
                attacks[a] = new DualStrike();
                GameInformation.Attacks = attacks;
                a++;
                break;
            case "ShockWave":
                attacks[a] = new ShockWave();
                GameInformation.Attacks = attacks;
                a++;
                break;
            default: break;
        }
		if (a == 9)
			a = 0;
	}
    public static void magicMove(string mMove)
    {
        Moves[] spells = GameInformation.Spells;
        switch (mMove)
        {
            case "Sparkles":
                spells[m] = new Sparkles();
                GameInformation.Spells = spells;
                m++;
                break;
            default: break;
        }
        if (m  == 9)
            m = 0;
    }

    public static void specialMove(string sMove)
    {
        Moves[] special = GameInformation.Specials;
        switch (sMove)
        {
            case "MagicWave":
                special[s] = new MagicWave();
                GameInformation.Specials = special;
                s++;
                break;
            default: break;
        }
        if (s == 5)
            s = 0;
    }
    // Update is called once per frame
    void Update () {
	
	}
	public static string[] AMoves{ get; set; }
	public static string[] MMoves{ get; set; }
	public static int A{ get; set; }
	public static int M{ get; set; }
}
