using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{

    private static bool monsterCreation;
    private static EnemyCreation create;

    // Use this for initialization
    void Start()
    {
        BattleController.Player = GameInformation.data();
        Debug.Log("BattleController.Player=null");
        BattleController.Battle = true;
        Energy energy = gameObject.GetComponent<Energy>();
        energy.enabled = true;
        EnemyCreation create = new EnemyCreation();
        EnemyMob = create.makeEnemy();
        Enemies = EnemyMob.Length;
        monsterCreation = true;
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
            monsterCreation = true;
            create.makeEnemy();
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
}
