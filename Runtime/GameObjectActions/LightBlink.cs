using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class LightBlink : MonoBehaviour {

        [SerializeField]
        private float minIntensity;
        [SerializeField]
        private float maxIntensity;
        [SerializeField]
        private float speed;

        private int dir = 1;

        private Light l;

        // Use this for initialization
        void Start () {
            l = GetComponent<Light>();
        }
        
        // Update is called once per frame
        void Update () {
            if (GetComponent<Light>().enabled)
            {
                float currentIntensity = l.intensity;
                if (currentIntensity>= maxIntensity)
                {
                    dir = -1;
                }
                else if(currentIntensity <= minIntensity)
                {
                    dir = 1;
                }
                l.intensity = currentIntensity + dir*speed * Time.deltaTime;

                l.intensity = Mathf.Clamp(l.intensity, minIntensity,maxIntensity);
            }
        }
    }
}