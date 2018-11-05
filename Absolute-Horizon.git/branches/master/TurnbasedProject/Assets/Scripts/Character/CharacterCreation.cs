using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CharacterCreation : MonoBehaviour
{

    private Player newPlayer;
    private string playerName;
    private bool isStudent;
    private bool isRoyal;



    // Use this for initialization.
    void Start()
    {
        NewPlayer = new Player();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {

        isStudent = GUILayout.Toggle(isStudent, "Student Class");
        isRoyal = GUILayout.Toggle(isRoyal, "Royal Class");
		BaseCharacterClass playerClass = null;
        if (GUILayout.Button("Create"))
        {
            if (isStudent)
            {
				playerClass = new StudentCharacterClass();
            }
            else if (isRoyal)
            {
				playerClass = new RoyalCharacterClass();
            }

			addClassToPlayer(playerClass);
            GameInformation.Actions.isMenu5Locked = true;
            GameInformation.Actions.isMenu3Locked = true;
            GameInformation.Actions.isMenu4Locked = true;
			MovesAssignment.assignMove("Stab");
			MovesAssignment.assignMove("DualStrike");
			MovesAssignment.assignMove("ShockWave");
            Debug.Log(GameInformtion.Spells[0]);
            Options.loadMoves();
			SceneManager.LoadScene ("BattleScence");

		}
	}
	public static Player NewPlayer{ get; set; }
}
