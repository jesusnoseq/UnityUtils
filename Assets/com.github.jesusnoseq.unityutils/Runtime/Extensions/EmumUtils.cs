using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


namespace com.jesusnoseq.util
{
    public static class EmumUtils
    {
        // Array to Dictionary
        public static Dictionary<int, T> ToDictionary<T>(this IEnumerable<T> array)
        {
            return array
                .Select((v, i) => new { Key = i, Value = v })
                .ToDictionary(o => o.Key, o => o.Value);
        }

        // string to enum
        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

    }
}
