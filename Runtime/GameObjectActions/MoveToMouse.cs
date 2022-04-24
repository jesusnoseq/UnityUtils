using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class MoveToMouse : MonoBehaviour {
        public float zPonterPos=10;

        void LateUpdate () {
            Vector3 mousePosition = MousePosition.Get();
            mousePosition.z = zPonterPos;
            Vector3 pos=Camera.main.ScreenToWorldPoint(mousePosition);

            pos.z = transform.position.z;
            transform.position = pos;
        }
    }

}
