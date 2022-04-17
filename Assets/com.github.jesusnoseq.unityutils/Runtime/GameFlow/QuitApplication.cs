using UnityEngine;


namespace com.jesusnoseq.util
{
    public class QuitApplication: MonoBehaviour
    {
        public static void Quit()
       {
            if (Application.isEditor)
            {
                //If we are running in the editor
                #if UNITY_EDITOR
                    //Stop playing the scene
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
            else
            {
                //If we are running in a standalone build of the game
                Application.Quit();
            }

        }
    }
}