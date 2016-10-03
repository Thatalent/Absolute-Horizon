using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;

public class EnemySelection : MonoBehaviour {

    public static EnemyClass[] World1Enemies { get; set; }
    public static EnemyClass[] World2Enemies { get; set; }
    public static EnemyClass[] World3Enemies { get; set; }
    public static EnemyClass[] World4Enemies { get; set; }


    public static EnemyClass [] World1GetEnemyList() {

       List<EnemyClass> objects = new List<EnemyClass>();

        foreach (Type type in Assembly.GetAssembly(typeof(EnemyClass)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EnemyClass)))) {
            objects.Add((EnemyClass)Activator.CreateInstance(type));
        }

        World1Enemies = objects.ToArray();
        
        return World1Enemies;

    }

    public static void World2GetEnemyList()
    {

        List<EnemyClass> objects = new List<EnemyClass>();

        foreach (Type type in Assembly.GetAssembly(typeof(EnemyClass)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EnemyClass))))
        {
            objects.Add((EnemyClass)Activator.CreateInstance(type));
        }

        foreach (EnemyClass e in objects) { Debug.Log(e.EnemyName); }
        Debug.Log(objects.ToString());
    }

    //public static void World3GetEnemyList()
    //{

    //    List<EnemyClass> objects = new List<EnemyClass>();

    //    foreach (Type type in Assembly.GetAssembly(typeof(EnemyClass)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EnemyClass))))
    //    {
    //        objects.Add((EnemyClass)Activator.CreateInstance(type));
    //    }

    //    foreach (EnemyClass e in objects) { Debug.Log(e.EnemyName); }
    //    Debug.Log(objects.ToString());
    //}

    //public static void World4GetEnemyList()
    //{

    //    List<EnemyClass> objects = new List<EnemyClass>();

    //    foreach (Type type in Assembly.GetAssembly(typeof(EnemyClass)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EnemyClass))))
    //    {
    //        objects.Add((EnemyClass)Activator.CreateInstance(type));
    //    }

    //    foreach (EnemyClass e in objects) { Debug.Log(e.EnemyName); }
    //    Debug.Log(objects.ToString());
    //}

}
