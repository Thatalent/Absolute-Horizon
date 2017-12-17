using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;

public class EnemySelection : MonoBehaviour
{

    public static Type[] World1Enemies { get; set; }
    public static Type[] World2Enemies { get; set; }
    public static Type[] World3Enemies { get; set; }
    public static Type[] World4Enemies { get; set; }

    public static Dictionary<string, EnemyMoves> TestWorldEnemyMoves { get; set; }
    public static Dictionary<string, EnemyMoves> World1EnemyMoves { get; set; }
    public static Dictionary<string, EnemyMoves> World2EnemyMoves { get; set; }
    public static Dictionary<string, EnemyMoves> World3EnemyMoves { get; set; }
    public static Dictionary<string, EnemyMoves> World4EnemyMoves { get; set; }


    public static void world1SetEnemyList()
    {

        List<Type> objects = new List<Type>();

        foreach (Type type in Assembly.GetAssembly(typeof(EnemyClass)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && typeof(TestWorld).IsAssignableFrom(myType)))
        {
            objects.Add(type);
        }

        foreach (Type e in objects)
        {
            Debug.Log(e);
        }

        World1Enemies = objects.ToArray();

    }

    public static EnemyClass[] getWorld1EnemyMob(int enemyNumber)
    {
        EnemyClass[] EnemyMob = new EnemyClass[enemyNumber];
        for (int i = 0; i < enemyNumber; i++)
        {
            Type type = (Type)EnemySelection.World1Enemies.GetValue(UnityEngine.Random.Range(0, EnemySelection.World1Enemies.Length));
            EnemyMob[i] = (EnemyClass)Activator.CreateInstance(type);
        }
        return EnemyMob;
    }

    public static void world2GetEnemyList()
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