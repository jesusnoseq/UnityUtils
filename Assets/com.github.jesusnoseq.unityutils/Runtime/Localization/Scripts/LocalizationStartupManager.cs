
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{

    public class LocalizationStartupManager : MonoBehaviour
    {
        public UnityEvent onLaguageLoaded;

        private IEnumerator Start()
        {
            string lang = PlayerPrefs.GetString(LocalizationManager.SELECTED_LANG_KEY, "");

            if (lang != "")
            {
                SystemLanguage systemLang = (SystemLanguage)Enum.Parse(typeof(SystemLanguage), lang, true);
                LocalizationManager.Instance.LoadLocalizationLanguage(systemLang);
            }
            else
            {
                LocalizationManager.Instance.LoadLocalizationLanguage(Application.systemLanguage);
            }
            while (!LocalizationManager.Instance.IsReady())
            {
                yield return null;
            }

            onLaguageLoaded.Invoke();
        }

        
    }
}