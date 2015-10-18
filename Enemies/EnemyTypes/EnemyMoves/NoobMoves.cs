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
            int choice = Random.Range(1, 3);
            switch (choice)
            {
                case 1: choice1();
                    yield return new WaitForSeconds(5);
                    break;

                default: yield return new WaitForSeconds(Random.Range(1f,6f));
                    break;
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
                move();

            }
        }
    }
    public override void move()
    {
        Attack attack = new Attack((gameObject.GetComponent<Enemy>().Attack + DmgBoost), GameInformtion.Defense);
        int damage = attack.attacking();
        GameInformtion.Health = GameInformtion.Health + damage;
        Debug.Log(GameInformtion.Health);

    }
}
