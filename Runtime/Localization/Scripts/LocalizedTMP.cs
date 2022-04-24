using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.jesusnoseq.util
{
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedTMP : LocalizedText
    {
        public override void TranslateText()
        {
            if (LocalizationManager.Instance != null)
            {
                string newText = "";
                TMP_Text textComp = GetComponent<TMP_Text>();
                if (useTextComponentTextAsKey)
                {
                    newText = LocalizationManager.Instance.GetLocalizedValue(textComp.text);
                }
                else
                {
                    newText = LocalizationManager.Instance.GetLocalizedValue(key);
                }
                textComp.text = newText;
            }
            else
            {
                Debug.LogWarning("LocalizationManager is not loaded");
            }
        }

    }
}

