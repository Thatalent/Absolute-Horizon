using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
            BattleController.Player = GameInformation.Data();
			MovesAssignment.AssignMove("Stab");
			MovesAssignment.AssignMove("DualStrike");
			MovesAssignment.AssignMove("ShockWave");
			MovesAssignment.AssignMove("Sparkles");
			MovesAssignment.AssignMove("MagicWave");
            Debug.Log(GameInformation.Actions.ActionsMenu1);
			Debug.Log(GameInformation.Actions.SpecialMenu);
            Debug.Log("Get World1 Enemy List");
			GameInitializer.startGame();
            SceneManager.LoadScene("BattleScence");
        }
    }

	public static void addClassToPlayer(BaseCharacterClass playerClass){
		
		NewPlayer.CharacterClass = playerClass;
		NewPlayer.PlayerLvl = 1;
        NewPlayer.Stamina = NewPlayer.CharacterClass.Stamina;
        Debug.Log(NewPlayer.Stamina);
        NewPlayer.Strength = NewPlayer.CharacterClass.Strength;
        NewPlayer.Endurance = NewPlayer.CharacterClass.Endurance;
        NewPlayer.Intelligence = NewPlayer.CharacterClass.Intelligence;
        NewPlayer.Resistance = NewPlayer.CharacterClass.Resistance;
        NewPlayer.Skill = NewPlayer.CharacterClass.Skill;
        NewPlayer.Speed = NewPlayer.CharacterClass.Speed;
        NewPlayer.Luck = NewPlayer.CharacterClass.Luck;
        NewPlayer.PlayerExp = 0f;
        GameInformation.save(NewPlayer);
	}

    public static Player NewPlayer { get; set; }
}
