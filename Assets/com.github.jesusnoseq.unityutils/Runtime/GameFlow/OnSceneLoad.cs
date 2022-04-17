using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{
    public class OnSceneLoad : MonoBehaviour
    {
        public UnityEvent levelLoadEvent;
        public IReady[] thingsToCheck; 


        private IEnumerator Start()
        {
            if (levelLoadEvent == null)
                levelLoadEvent = new UnityEvent();

            thingsToCheck = GetComponents<IReady>();
            if (thingsToCheck.Length == 0)
                levelLoadEvent.Invoke();



            yield return new WaitUntil(CheckComponents);
        
            levelLoadEvent.Invoke();
        }

        private bool CheckComponents()
        {
            for (int i=0;i< thingsToCheck.Length;i++)
            {
                if (!thingsToCheck[i].IsReady())
                    return false;
            }
            return true;
        }

    }
}
