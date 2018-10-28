using UnityEngine;
using System.Collections;

public class EnemyEnergy : MonoBehaviour {

    //private static Player player;

    // Use this for initialization
    void Start()
    {
        //Player = GameInformtion.data ();
        battleController = GameObject.Find("Player-Character").GetComponent<BattleController>();
        StartCoroutine(energyRate());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator energyRate()
    {
        bool battle = battleController.ActiveBattle;
        //Debug.Log(GameInformtion.Energy);
        while (true)
        {

            yield return new WaitForSeconds(1);
            if (GetComponent<Enemy>().Energy < GetComponent<Enemy>().MaxEnergy && !battleController.ActiveEnemy)
            {
                GetComponent<Enemy>().Energy = GetComponent<Enemy>().Energy + GetComponent<Enemy>().EnergyRate;
                //yield return new WaitForSeconds(10);
                // Debug.Log(gameObject.GetComponent<Enemy>().Energy);
                if (GetComponent<Enemy>().Energy > GetComponent<Enemy>().MaxEnergy)
                {
                    GetComponent<Enemy>().Energy = GetComponent<Enemy>().MaxEnergy;
                    //  yield return new WaitForSeconds(2f);
                }
            }
        }
    }
    //public static Player Player{ get; set; }

    public BattleController battleController { get; set; }
}