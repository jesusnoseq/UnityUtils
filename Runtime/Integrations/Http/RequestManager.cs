using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace com.jesusnoseq.util
{
    public delegate void OnRequestCompleteCallBack(string result);

    public class RequestManager : MonoBehaviour { 

        public void Get(String url, OnRequestCompleteCallBack callback)
        {
            StartCoroutine(GetCor(url, callback));
        }

        public void Post(String url, string form, OnRequestCompleteCallBack callback)
        {
            StartCoroutine(PostCor(url, form, callback));
        }

        private IEnumerator GetCor(string url, OnRequestCompleteCallBack callback)
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            if (www.error == null)
            {
                callback(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("GET ERROR: " + www.error);
            }
        }

        private IEnumerator PostCor(string url, string postData, OnRequestCompleteCallBack callback)
        {
            UnityWebRequest www = UnityWebRequest.Post(url, postData);
            www.SetRequestHeader("Content-Type", "application/json");
     
            yield return www.SendWebRequest();

            if (www.error == null)
            {
                callback(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("POST ERROR: " + www.error);
            }
        }

    }
}