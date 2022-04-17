using UnityEngine;
#if ENABLE_INPUT_SYSTEM
    using UnityEngine.InputSystem;
#endif


namespace com.jesusnoseq.util
{

    public static class MousePosition
    {
        public static Vector2 Get() {
            #if ENABLE_INPUT_SYSTEM
                    Vector2 mousePosition = Mouse.current.position.ReadValue();
            #else
                    Vector2 mousePosition = Input.mousePosition;
            #endif
            return mousePosition;
        }

    }
}
