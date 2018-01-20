using UnityEngine;
using System.Collections;

public class ReactionInput : MonoBehaviour {

    private enum UserCommands { ATTACK, MAGIC, SPECIAL }

	// Use this for initialization
	void Start () {
        ReactionImage = GetComponent<SpriteRenderer>();
        ReactionSprites = new Sprite[3];
        ReactionSprites[0] = Resources.Load<Sprite>("Keyboard-key-icons_90");
        ReactionSprites[1] = Resources.Load<Sprite>("Keyboard-key-icons_82");
        ReactionSprites[2] = Resources.Load<Sprite>("Keyboard-key-icons_81");
    }

    // Update is called once per frame
    void Update () {
	    
        if(ReactionCommands != null && ReactionCommands.Length > 0)
        {
            if (UserCommands.ATTACK.Equals(ReactionCommands[inputCounter]))
            {
                ReactionImage.sprite = ReactionSprites[0];
            }
        }
	}

    public int[] ReactionCommands { get; set; }
    public int inputCounter { get; set; }
    public SpriteRenderer ReactionImage { get; set; }
    public Sprite[] ReactionSprites;
}
