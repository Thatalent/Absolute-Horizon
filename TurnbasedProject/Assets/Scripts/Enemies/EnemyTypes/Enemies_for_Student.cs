using UnityEngine;
using System.Collections;

public class Enemies_for_Student : EnemyCreation {


    override
     public EnemyClass[] getEnemyTypes(int enemyNumber)
    {
        EnemyClass[] listOfEnemies = new EnemyClass[enemyNumber];
        return listOfEnemies;
    }
}
