using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public static class RandUtils
    {
        public static T RandomEnumValue<T>()
        {
            var values = System.Enum.GetValues(typeof(T));
            int random = UnityEngine.Random.Range(0, values.Length);
            return (T)values.GetValue(random);
        }

        public static T RandomItemFromList<T> (List<T> l)
        {
            return (T)l[Random.Range(0, l.Count)];
         }
    }
}