using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{
    public class SinMove : MonoBehaviour {
        
        public float frequency=1;
        public float magnitude=1;
        public Vector3 moveVector = Vector3.up;
        public bool rand;
        private float randNumber;

        // Use this for initialization
        void Start () {
            randNumber = Random.value;
        }
        
        // Update is called once per frame
        void Update () {
            transform.position = transform.position + moveVector * Mathf.Sin((Time.time+ randNumber) * frequency) * magnitude * Mathf.CeilToInt(Time.deltaTime);
        }
    }
}
