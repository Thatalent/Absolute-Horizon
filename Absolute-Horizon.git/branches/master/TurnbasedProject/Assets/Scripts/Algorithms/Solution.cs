using UnityEngine;
using System.Collections;

//Use class to add algorithms, repeative proceses and other utlity based functions.

public class Solution{

    public static void quickSort(int[] ar, int lo, int hi)
    {

        int pa = hi;

        if (lo < hi)
        {
            pa = partition(ar, lo, hi);
            quickSort(ar, lo, pa - 1);
            quickSort(ar, pa + 1, hi);
        }
    }
    public static int partition(int[] ar, int lo, int hi)
    {
        int pI = hi;
        int pV = ar[pI];
        int sI = lo;
        for (int i = lo; i < hi; i++)
        {
            if (ar[i] < pV)
            {
                int temp1 = ar[i];
                ar[i] = ar[sI];
                ar[sI] = temp1;
                sI++;
            }
        }
        int temp = ar[hi];
        ar[hi] = ar[sI];
        ar[sI] = temp;
        return sI;
    }

    public static void printArray(int[] ar)
    {
        for (int h = 0; h < ar.Length; h++)
        {
           // System.out.print(ar[h] + " ");
        }
        //System.out.println("");
    }
}
