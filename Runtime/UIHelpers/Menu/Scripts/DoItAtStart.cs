using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace com.jesusnoseq.util
{
    public class DoItAtStart : MonoBehaviour
    {
        public UnityEvent onStartEvent;


        // Use this for initialization
        void Start()
        {
            if (onStartEvent == null)
                onStartEvent = new UnityEvent();

            onStartEvent.Invoke();
        }
    }
}
