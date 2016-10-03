using UnityEngine;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class Thing {

    public static void GetEnemyList(){

        List<EnemyClass> objects = new List<EnemyClass>();

        foreach (Type type in Assembly.GetAssembly(typeof(EnemyClass)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EnemyClass)))){
            objects.Add((EnemyClass)Activator.CreateInstance(type));
        }

        foreach (EnemyClass e in objects) { Debug.Log(e.EnemyName); }
        Debug.Log(objects.ToString());
    }


}
