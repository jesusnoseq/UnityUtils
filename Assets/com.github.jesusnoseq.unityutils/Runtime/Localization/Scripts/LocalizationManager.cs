using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace com.jesusnoseq.util
{

    public class LocalizationManager : MonoBehaviourSingletonPersistent<LocalizationManager>
    {
        private string fileLoaded;
        private SystemLanguage languageLoaded;
        private Dictionary<string, string> localizedText;
        private bool isReady = false;

        private const string missingTextMsg = "{0} key not found";
        private const string missingFileSMsg = "Cannot find file {0}";
        private const string notLoadedFileMsg = "Language file is not loaded";
        private const string notLoadedFileYetMsg = "Language file is not loaded yet. Enable waitUtilFileLoaded checkbox or load the language file before use it.";

        public const string SELECTED_LANG_KEY = "selectedLang";

        public bool waitUtilFileLoaded = true;
        public float loadFileTimeout = 3f;
        public SystemLanguage defaultLanguage = SystemLanguage.English;
        public Dictionary<SystemLanguage, string> languageFilesDict;
        public LanguageFile[] laguageFiles;
        

        public void LoadLocalizationLanguage(SystemLanguage language)
        {
            if (languageFilesDict==null)
            {
                languageFilesDict = laguageFiles.ToDictionary(o => o.language, o => o.filename);
            }
            
            languageLoaded = language;
            if (languageFilesDict.ContainsKey(language))
            {
                LoadLocalizationFile(languageFilesDict[language]);
            }else
            {
                LoadLocalizationFile(languageFilesDict[defaultLanguage]);
            }
        }

        public void LoadLocalizationFile(string fileName)
        {
            string filePath = fileName.Replace(".json", "");
            TextAsset file = Resources.Load(filePath) as TextAsset;
            if (file != null)
            {
                localizedText = new Dictionary<string, string>();
                string dataAsJson = file.text;
                LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

                for (int i = 0; i < loadedData.items.Length; i++)
                {
                    localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
                }

                //Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
            }
            else
            {
                Debug.LogError(string.Format(missingFileSMsg, fileName));
            }
            fileLoaded = fileName;
            isReady = true;
        }

        public string GetLocalizedValue(string key)
        {
            string result=key;

            if (!IsReady())
            {
                if (waitUtilFileLoaded)
                {
                    StartCoroutine(GetLocalizedValueRetryCor(key));
                }
                else
                {
                    Debug.LogError(notLoadedFileYetMsg);
                }
            }else if (localizedText.ContainsKey(key))
            {
                result = localizedText[key];
            }else{
                result = string.Format(missingTextMsg, key);
                Debug.LogWarning(result);
            }

            return result;
        }

        private IEnumerator GetLocalizedValueRetryCor(string key)
        {
            float timer = 0f;
            while (!IsReady())
            {
                if (timer > loadFileTimeout) { break; }
                timer += Time.deltaTime;
                yield return null;
            }
            if (IsReady())
            {
                GetLocalizedValue(key);
            }else
            {
                Debug.LogError(notLoadedFileMsg);
            }
        }

        public string GetFileLoaded()
        {
            return fileLoaded;
        }

        public bool IsReady()
        {
            return isReady;
        }

    }
}