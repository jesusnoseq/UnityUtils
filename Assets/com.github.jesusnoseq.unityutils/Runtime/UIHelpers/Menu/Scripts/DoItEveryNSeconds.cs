using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{
    public class DoItEveryNSeconds : MonoBehaviour
    {
        [Tooltip("Launch event every x seconds")]
        public float time = 1;
        [Tooltip("Times to launch the event, negative is infinite")]
        public int times=-1;
        public bool launchAtStart = false;
        public UnityEvent onTimeEvent;

        

        private float launchTime;

        // Use this for initialization
        void Start()
        {
            if (onTimeEvent == null)
                onTimeEvent = new UnityEvent();

            if (launchAtStart)
            {
                onTimeEvent.Invoke();
            }
            launchTime = Time.time;
        }

        void Update()
        {
            if ((Time.time-launchTime)> time && times!=0)
            {
                onTimeEvent.Invoke();
                launchTime = Time.time;
                times--;
            }
        }

    }
}
