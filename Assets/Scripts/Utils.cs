using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = list.Count; i > 0; i--)
        {
            list.Swap(0, Random.Range(0, i));
        }
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        (list[i], list[j]) = (list[j], list[i]);
    }
}