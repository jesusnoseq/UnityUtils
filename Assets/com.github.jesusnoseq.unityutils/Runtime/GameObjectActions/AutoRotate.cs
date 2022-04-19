using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class AutoRotate : MonoBehaviour
    {
        public Vector3 rotatinSpeed;
        public Space space;

        void Update()
        {
            gameObject.transform.Rotate(rotatinSpeed*Time.deltaTime, space);
        }
    }

}