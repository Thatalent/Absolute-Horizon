using UnityEngine;
using System.Collections;

public class NoobMoves : EnemyMoves {

	// Use this for initialization
	void Start () {
        StartCoroutine(enemyChoice());
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    protected override IEnumerator enemyChoice()
    {
        yield return new WaitForSeconds(1);
        while (gameObject.GetComponent<Enemy>().Health>0)
        {
            if (!battleController.Model.ActiveTurn)
            {
                int choice = Random.Range(1, 3);
                switch (choice)
                {
                    case 1:
                        battleController.ActiveEnemy = true;
                        Debug.Log("Trying to attack! >:3");
                        choice1();
                        Debug.Log("Finished attacking! :3");
                        battleController.ActiveEnemy = false;
                        yield return new WaitForSeconds(2);
                        break;

                    default:
                        yield return new WaitForSeconds(Random.Range(1f, 2f));
                        Debug.Log("Doing nothing :)");
                        break;
                }
            }
            else
            {
                
                yield return new WaitForFixedUpdate();
            }
        }
    }
    protected  override void choice1()
    {
        if (gameObject.GetComponent<Enemy>().Energy > 5)
        {
            EpUse = 5;
            HitRate = 1f;
            gameObject.GetComponent<Enemy>().Energy = gameObject.GetComponent<Enemy>().Energy - EpUse;
            float hit = accuracy();
            if (Random.value <= hit)
            {
                MoveName = "Punch";
                Debug.Log("Falcooooooon-");
                Debug.Log(MoveName + "!");
                move();

            }
            else
                Debug.Log("Missed!!! 3:>");
        }
    }
    public override void move()
    {
        Attack attack = new Attack((gameObject.GetComponent<Enemy>().Attack + DmgBoost), GameInformation.Defense);
        int damage = attack.attacking();
        GameInformation.Health = GameInformation.Health + damage;
        BaseStatusBar status = GameObject.FindGameObjectWithTag("Player_HealthBar").GetComponent<BaseStatusBar>() ;
        status.changeStatusSize(GameInformation.Health, GameInformation.MaxHealth);

        Debug.Log(GameInformation.Health);
        

    }
}
