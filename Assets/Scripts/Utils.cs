using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    // https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-enum-value-in-c-sharp
    public static T Next<T>(this T src) where T : Enum
    {
        if (!typeof(T).IsEnum) Debug.LogError(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf(Arr, src) + 1;
        //return (Arr.Length == j) ? Arr[0] : Arr[j];
        return (Arr.Length == j) ? Arr[j-1] : Arr[j];
    }

    public static T Prev<T>(this T src) where T : Enum
    {
        if (!typeof(T).IsEnum) Debug.LogError(string.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf(Arr, src) - 1;
        //return (j < 0) ? Arr[Arr.Length - 1] : Arr[j];
        return (j < 0) ? Arr[j + 1] : Arr[j];
    }
}
