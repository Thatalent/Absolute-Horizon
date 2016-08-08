using UnityEngine;
using System.Collections;

public class Enemies_for_Royality : EnemyCreation {

    override
     public EnemyClass[] getEnemyTypes(int enemyNumber)
    {
        EnemyClass[] listOfEnemies = new EnemyClass[enemyNumber];
        return listOfEnemies;
    }

}
