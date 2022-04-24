using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;


namespace com.jesusnoseq.util
{
    [DisallowMultipleComponent]
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        public bool disableOnHide;// { get; protected set; }
        [SerializeField]
        public bool manageBackButton;// { get; protected set; }

        public UnityEvent OnBackButton;

        protected List<MenuPanel> windowsList;
        protected int nWindows;
        protected MenuPanel previousWindow;
        protected MenuPanel currentWindow;

        private MenuPanel CurrentWindow
        {
            get
            {
                return currentWindow;
            }
            set
            {
                previousWindow = currentWindow;
                currentWindow = value;
            }
        }

        protected virtual void Start()
        {
            windowsList = new List<MenuPanel>(GetComponentsInChildren<MenuPanel>(true));
            nWindows = windowsList.Count;
            for (int i = 0; i < nWindows; i++)
            {
                windowsList[i].SetMenuManager(this);
                if (windowsList[i].isActiveAndEnabled)
                {
                    currentWindow = windowsList[i];
                }
            }

            if (OnBackButton == null)
                OnBackButton = new UnityEvent();

            OnBackButton.AddListener(OnBackButtonPressed);
        }

        protected virtual void Update()
        {
            // Android back button = KeyCode.Escape
            if (manageBackButton && Input.GetKeyDown(KeyCode.Escape))
            {
                //OnBackButtonPressed();
                OnBackButton.Invoke();
            }
        }

        public virtual void OnBackButtonPressed()
        {
            if (previousWindow != null && currentWindow.isPopUp)
            {
                ActiveWindow(previousWindow);
            }
            else
            {
                QuitApplication.Quit();
            }
        }

        public virtual void ActiveWindow(MenuPanel w)
        {
            if (currentWindow != w)
            {
                if (!w.GetComponent<MenuPanel>().isPopUp)
                {
                    for (int i = 0; i < nWindows; i++)
                    {
                        if (windowsList[i].isActiveAndEnabled && windowsList[i] != w)
                        {
                            windowsList[i].Hide(disableOnHide);
                        }
                    }
                }
                w.transform.SetAsLastSibling();
                CurrentWindow = w;
                w.Show();
            }
        }


        public virtual void DisableWindow(MenuPanel w)
        {
            w.Hide();
            CurrentWindow = previousWindow;
            previousWindow.transform.SetAsLastSibling();
        }
    }
}
