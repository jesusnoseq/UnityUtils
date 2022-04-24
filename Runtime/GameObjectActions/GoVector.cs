using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{
    public class GoVector : MonoBehaviour {
        public float speed = 5f;
        public Vector3 dir;

        // Update is called once per frame
        void Update () {
            transform.Translate(dir * speed*Time.deltaTime);
        }
    }

}