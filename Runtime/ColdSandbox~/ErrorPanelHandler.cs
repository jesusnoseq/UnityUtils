using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.jesusnoseq.util
{
    public class ErrorPanelHandler : MonoBehaviourSingleton<ErrorPanelHandler>
    {
        public GameObject panel;
        public TMP_Text errorText;

        public int timeout = 5;

        private void Start()
        {
            Invoke("ShowError", timeout);
        }

        public void ShowError()
        {
            panel.SetActive(true);
        }

        public void ShowError(string errorMsg)
        {
            errorText.text = errorMsg;
            panel.SetActive(true);
        }
    }
}