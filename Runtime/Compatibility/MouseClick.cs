using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
    using UnityEngine.InputSystem;
#endif

namespace com.jesusnoseq.util
{
    [DisallowMultipleComponent]
    public class MouseClick : MonoBehaviourSingleton<MouseClick>
    {

        private static bool left=false;
        private static bool right=false;

        
        public static bool LeftClick() {
            #if ENABLE_INPUT_SYSTEM
                return Mouse.current.leftButton.wasReleasedThisFrame;
            #else
                var tempLeft=left;
                left=false;
                return tempLeft;
            #endif
        }

        public static bool RightClick() {
            #if ENABLE_INPUT_SYSTEM
                return Mouse.current.rightButton.wasReleasedThisFrame;
            #else
                var tempRight=right;
                right=false;
                return tempRight;
            #endif
        }

        #if !ENABLE_INPUT_SYSTEM
            public void Update() 
            {
                if (Input.GetMouseButtonUp(0)) 
                { 
                    left = true;
                }
                if (Input.GetMouseButtonUp(1)) 
                { 
                    right = true;
                } 
            }
        #endif
    }

}
