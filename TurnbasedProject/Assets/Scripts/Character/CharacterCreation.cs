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
        if (GUILayout.Button("Create"))
        {
            if (isStudent)
            {
                NewPlayer.CharacterClass = new StudentCharacterClass();
            }
            else if (isRoyal)
            {
                NewPlayer.CharacterClass = new RoyalCharacterClass();
            }
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
            GameInformation.World = 0;
            GameInformation.Zone = 0;
            GameInformation.Location = 0;
            GameInformation.Area = 0;
            BattleController.Player = GameInformation.data();
            Debug.Log(BattleController.Player.Skill);
            MovesAssignment.attackMove("Stab");
            MovesAssignment.attackMove("DualStrike");
            MovesAssignment.attackMove("ShockWave");
            MovesAssignment.magicMove("Sparkles");
            Debug.Log(GameInformation.Spells[0]);
            Options.loadMoves();
            Debug.Log("Get World1 Enemy List");
            EnemySelection.world1SetEnemyList();
            SceneManager.LoadScene("BattleScence");

        }
    }
    public static Player NewPlayer { get; set; }
}
