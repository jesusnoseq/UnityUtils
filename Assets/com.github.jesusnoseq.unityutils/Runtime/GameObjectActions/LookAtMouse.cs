using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.jesusnoseq.util;
#if ENABLE_INPUT_SYSTEM
    using UnityEngine.InputSystem;
#endif


namespace com.jesusnoseq.util
{
    public class LookAtMouse : MonoBehaviour {

        // Use this for initialization
        void Start () {
            
        }
        
        // Update is called once per frame
        void Update () {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            Vector2 mousePosition = MousePosition.Get();

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(mousePosition);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(mouseOnScreen, positionOnScreen);

            //Ta Daaa
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));



            /*Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 wordlMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);



            /*Vector3 relativePos = wordlMousePos - transform.position;
            Quaternion rot = Quaternion.LookRotation(relativePos);
            float rotX = 0;
            float rotZ = rot.eulerAngles.y;
            float rotY = 0;
            rot.eulerAngles = new Vector3(rotX, rotY, rotZ);
            transform.rotation = rot;*/
        }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

    }

}