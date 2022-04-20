using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

namespace com.jesusnoseq.util
{
    public class MenuScript : MonoBehaviour{

        private List<Window> windowsList;
        private int nWindows;

        public void Start()
        {
            windowsList = new List<Window>(GetComponentsInChildren<Window>(true));
            nWindows = windowsList.Count;
        }


        public void LoadGameScene(Window loadingPanel)
        {
            loadingPanel.OnShow();
            //SceneManager.LoadScene(1);
        }

        public void ActiveWindow(Window w)
        {
            if (!w.GetComponent<Window>().isPopUp)
            {
                for (int i = 0; i < nWindows; i++)
                {
                    windowsList[i].OnHide();//gameObject.SetActive(false);
                }
            }

            w.OnShow();//gameObject.SetActive(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }


    }
}