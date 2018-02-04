using UnityEngine;
using System.Collections;
using System;

public class ReactionInput : MonoBehaviour {

    private enum UserCommands { ATTACK, MAGIC, SPECIAL }
    public enum InputType { RANDOM, RAPID, STRING }

    // Use this for initialization
    void Start () {
        ReactionImage = GetComponent<SpriteRenderer>();
        ReactionSprites = new Sprite[3];
        Sprite[] reactionsprites = Resources.LoadAll<Sprite>("Keyboard-key-icons");
        ReactionSprites[0] = reactionsprites[90];
        ReactionSprites[1] = reactionsprites[82];
        ReactionSprites[2] = reactionsprites[71];
    }

    // Update is called once per frame
    void Update () {
	    
        if(ReactionReady && ReactionCommands != null && ReactionCommands.Length > 0)
        {
            if ((int)UserCommands.ATTACK == ReactionCommands[inputCounter])
            {
                ReactionImage.sprite = ReactionSprites[(int)UserCommands.ATTACK];
                if (Input.GetButtonDown("attack"))
                {
                    SuccessfulInputs++;
                    FloatingText.Show(SuccessfulInputs.ToString(), "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, 0.5f, 0));
                    if (ReactionType != InputType.RAPID)
                    {
                        inputCounter++;
                    }
                }
            }
            else if ((int)UserCommands.MAGIC == ReactionCommands[inputCounter])
            {
                ReactionImage.sprite = ReactionSprites[(int)UserCommands.MAGIC];
                if (Input.GetButtonDown("magic"))
                {
                    SuccessfulInputs++;

                    if (ReactionType != InputType.RAPID)
                    {
                        inputCounter++;
                    }
                }
            }
            else if ((int)UserCommands.SPECIAL == ReactionCommands[inputCounter])
            {
                ReactionImage.sprite = ReactionSprites[(int)UserCommands.SPECIAL];
                if (Input.GetButtonDown("special"))
                {
                    SuccessfulInputs++;

                    if (ReactionType != InputType.RAPID)
                    {
                        inputCounter++;
                    }
                }
            }
            
        }
        if(ReactionReady && inputCounter >= ReactionCommands.Length)
        {
            inputCounter = 0;
            ReactionReady = false;
            StopAllCoroutines();
            ReactionImage.sprite = null;
            FloatingText.Show("SUCCESS!!!", "EnemyDamageTaken", new FromWorldPointPositioner(Camera.main, GameObject.Find("Text_Generator").transform.position, 1.5f, 0));
            ReactionCallback(SuccessfulInputs);
        }
    }

    public IEnumerator countSuccessfulInput(float timeToWait)
    {
        ReactionReady = true;

        yield return new WaitForSeconds(timeToWait);

        ReactionReady = false;
        ReactionCommands = null;
        ReactionImage.sprite = null;
        ReactionCallback(SuccessfulInputs);
    }

    public void startReactionCounter(float timeToReact, int[] reactionCommands, InputType reactionType)
    {
        ReactionCommands = reactionCommands;
        ReactionType = reactionType;
        StartCoroutine(countSuccessfulInput(timeToReact));
    }

    public int[] ReactionCommands { get; set; }
    public int inputCounter { get; set; }
    public int SuccessfulInputs { get; set; }
    public InputType ReactionType { get; set; }
    public bool ReactionReady { get; set; }
    public SpriteRenderer ReactionImage { get; set; }
    public Sprite[] ReactionSprites { get; set; }
    public Action<int> ReactionCallback { get; set; }
}
