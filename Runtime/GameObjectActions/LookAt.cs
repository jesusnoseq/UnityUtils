using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class LookAt : MonoBehaviour {
            public Transform target;


        void Update()
        {
            Vector3 relativePos = target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, relativePos);
        }
    }

}