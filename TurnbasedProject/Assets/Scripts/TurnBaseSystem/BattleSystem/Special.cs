using UnityEngine;
using System.Collections;
using System;

public class Special {

	public Special (Player player, ReactionInput.InputType inputType, float timeToReact)
    {

        Player = player;
        InputType = inputType;
        TimeToReact = timeToReact;
	}

    public void perform()
    {
        generateInputList();

        ReactionInput reactIp = GameObject.FindGameObjectWithTag("ReactionInput").GetComponent<ReactionInput>();

        reactIp.ReactionCallback = setTotalDmg;

        reactIp.startReactionCounter(TimeToReact, CommandList, InputType);

    }

    public void setTotalDmg(int successCounter)
    {
        float successRating;

        int attackPow = BattleController.Player.Attack + BattleController.Player.Magic;

        if (InputType.Equals(ReactionInput.InputType.RAPID))
        {
            successRating = successCounter / (TimeToReact * 3.5f);
        }
        else
        {
            successRating = successCounter / CommandList.Length;
        }

        TDmg = (int)(attackPow * successRating);

        SpecialCallback(TDmg);
    }

    static public int getEnemyDmg(int dmg, int eDef)
    {
        return -(dmg - eDef);
    }

    public void generateInputList()
    {

        if(CommandList == null)
        {
            int listSize;
            if(InputType.Equals(1))
            {
                listSize = 1;
            }
            else
            {
                listSize = UnityEngine.Random.Range(1, 6);
            }

            CommandList = new int[listSize];

            for(int i=0; i < listSize; i++)
            {
                CommandList[i] = UnityEngine.Random.Range(0, 3);
            }
        }
    }

    public bool effectRate(float rate)
    {

        if (1.0f - rate < UnityEngine.Random.value)
        {
            return true;
        }
        return false;
    }

    private int TDmg{ get; set; }
    private float TimeToReact { get; set; }
    private Player Player{ get; set; }
	private Enemy Enemy{ get; set; }
	private int EDef{ get; set; }
    public ReactionInput.InputType InputType { get; set; }
    public int[] CommandList { get; set; }
    public Action<int> SpecialCallback { get; set; }
}
