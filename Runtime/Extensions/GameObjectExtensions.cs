using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace com.jesusnoseq.util
{
    public static class GameObjectExtensions {
        // find the first T interface in a gameobject
        // source https://forum.unity.com/threads/getcomponents-possible-to-use-with-c-interfaces.60596/
        public static T GetInterface<T>(this GameObject inObj) where T : class
        {
            return inObj.GetComponents<Component>().OfType<T>().FirstOrDefault();
        }


        // find T interfaces in a gameobject
        // source https://forum.unity.com/threads/getcomponents-possible-to-use-with-c-interfaces.60596/
        public static IEnumerable<T> GetInterfaces<T>(this GameObject inObj) where T : class
        {
            return inObj.GetComponents<Component>().OfType<T>();
        }
    }

}
