using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


namespace com.jesusnoseq.util
{
    [System.Serializable]
    [RequireComponent(typeof(TMP_Text))]
    public class Countdown : MonoBehaviour
    {

        [SerializeField]
        public float counterBackTo;
        private float counterTime;

        [SerializeField]
        public int decimals=0;

        [SerializeField]
        public UnityEvent OnStart;
        public UnityEvent OnEnd;

        [SerializeField]
        private bool hideOnNotRunning = true;

        [SerializeField]
        private bool counterOnStart = true;

        private TMP_Text counterText;

        private bool running = false;
        private bool ended = false;



        // Use this for initialization
        void Start()
        {
            if (counterOnStart){
                StartCounter();
            }
            counterTime = counterBackTo;
            counterText=GetComponent<TMP_Text>();
            counterText.text = counterTime.ToString("F" + decimals);
        }

        // Update is called once per frame
        void Update()
        {
            if (!ended && running)
            {
                if (counterText.enabled==false)
                {
                    counterText.enabled = true;
                }
                if (counterTime == 0)
                {
                    EndCounter();
                }
                counterText.text = counterTime.ToString("F"+decimals);
                counterTime -= Time.deltaTime;
                counterTime = Mathf.Clamp(counterTime, 0, counterBackTo);
                
            }
        }


        public void StartCounter()
        {
            running = true;
            OnStart.Invoke();
        }

        public void EndCounter(){
            ended = true;
            running = false;
            if (hideOnNotRunning){
                counterText.enabled = false;
            }
            OnEnd.Invoke();
        }

        public void PauseCounter()
        {
            running = false;
        }

        public void ResetCounter()
        {
            running = false;
            ended = false;
            counterTime = counterBackTo;
        }
    }
}