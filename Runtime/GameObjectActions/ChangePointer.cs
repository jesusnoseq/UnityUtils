using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{
    public class ChangePointer : MonoBehaviour {
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;


        // Use this for initialization
        void Start () {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        private void OnDestroy()
        {
            setToNormal();
        }

        public void setToNormal()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        

    }

}
