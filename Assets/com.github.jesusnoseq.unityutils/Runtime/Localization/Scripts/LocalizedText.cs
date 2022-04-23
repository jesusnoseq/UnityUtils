using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.jesusnoseq.util
{
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        [Tooltip("If useTextComponentTextAsKey is active the key field of this component will not be used")]
        public bool useTextComponentTextAsKey = true;
        public string key;
        

        void Start()
        {
            TranslateText();
        }

        public virtual void TranslateText()
        {
            if (LocalizationManager.Instance != null)
            {
                string newText = "";
                Text textComp = GetComponent<Text>();
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

