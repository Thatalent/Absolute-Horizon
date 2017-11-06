using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour, BattleControllerService
{

    private static bool monsterCreation;
    private static EnemyCreation Create { get; set; }

    // Use this for initialization
    void Start()
    {
        BattleController.Player = GameInformation.data();
        Debug.Log("BattleController.Player=null");
        BattleController.Battle = true;
        Energy energy = gameObject.GetComponent<Energy>();
        energy.enabled = true;
        Create = new EnemyCreation();
        EnemyMob = Create.makeEnemy();
        Enemies = EnemyMob.Length;
        monsterCreation = true;
        Enemy = EnemyMob[EnemyIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemies == 0)
        {
            Battle = false;
        }
        if (GameObject.FindGameObjectWithTag("Enemy") && !monsterCreation)
        {
            Enemies = EnemyMob.Length;

        }
        if (Battle == false)
        {
            SceneManager.LoadScene("CharacterCreation");
        }
        Enemies = EnemyMob.Length;
    }

    public static Player Player { get; set; }
    public static GameObject Enemy { get; set; }
    public static int Enemies { get; set; }
    public static bool Battle { get; set; }
    public static GameObject[] EnemyMob { get; set; }
    public static int EnemyIndex { get; set; }
}
