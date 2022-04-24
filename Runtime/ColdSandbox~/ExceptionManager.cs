using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{

    public class ExceptionManager : MonoBehaviourSingletonPersistent<ExceptionManager>
    {
        
        override public void InitOnce()
        {
            Application.logMessageReceived += HandleException;
            DontDestroyOnLoad(gameObject);
        }

        void HandleException(string condition, string stackTrace, LogType type)
        {
            if (type == LogType.Exception)
            {
                
            }
        }
    }

}