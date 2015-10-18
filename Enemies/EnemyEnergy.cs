using UnityEngine;
using System.Collections;

public class EnemyEnergy : MonoBehaviour {

    //private static Player player;

    // Use this for initialization
    void Start()
    {
        //Player = GameInformtion.data ();
        StartCoroutine(energyRate());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator energyRate()
    {
        bool battle = BattleController.Battle;
        //Debug.Log(GameInformtion.Energy);
        while (true)
        {
            Debug.Log(gameObject.GetComponent<Enemy>().Energy);

            yield return new WaitForSeconds(1);
            if (gameObject.GetComponent<Enemy>().Energy < gameObject.GetComponent<Enemy>().MaxEnergy)
            {
                gameObject.GetComponent<Enemy>().Energy = gameObject.GetComponent<Enemy>().Energy + gameObject.GetComponent<Enemy>().EnergyRate;
                //yield return new WaitForSeconds(10);
                Debug.Log(gameObject.GetComponent<Enemy>().Energy);
                if (gameObject.GetComponent<Enemy>().Energy > gameObject.GetComponent<Enemy>().MaxEnergy)
                {
                    gameObject.GetComponent<Enemy>().Energy = gameObject.GetComponent<Enemy>().MaxEnergy;
                    //  yield return new WaitForSeconds(2f);
                }
            }
        }
    }
    //public static Player Player{ get; set; }
}