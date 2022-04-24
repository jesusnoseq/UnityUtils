using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.jesusnoseq.util
{
    public class LoadScene : MonoBehaviour
    {
        public string sceneName;

        public void Load()
        {
            SceneManager.LoadScene(sceneName);
        }


        public void Load(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
