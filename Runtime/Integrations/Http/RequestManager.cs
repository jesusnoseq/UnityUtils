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
            if (!www.isHttpError && !www.isNetworkError)
            {
                callback(www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("GET ERROR: " + www.error);
                PrintRequestInfo(www);
            }
        }

        private IEnumerator PostCor(string url, string postData, OnRequestCompleteCallBack callback)
        {
            var raw = System.Text.Encoding.UTF8.GetBytes(postData);
            UnityWebRequest www =new UnityWebRequest(url, "POST");
            www.uploadHandler = (UploadHandler) new UploadHandlerRaw(raw);
            www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            
            yield return www.SendWebRequest();

            if (!www.isHttpError && !www.isNetworkError)
            {
                callback(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("POST ERROR: " + www.error);
                PrintRequestInfo(www);
            }
        }

        private void PrintRequestInfo(UnityWebRequest www){
                Debug.Log("Request debug info \n"+
                    "isDone "+www.isDone +"\n"+
                    "isNetworkError  "+www.isNetworkError+"\n"+
                    "isHttpError  "+www.isHttpError+"\n"+
                    "text "+www.downloadHandler.text+"\n"+
                    "result "+www.result+"\n"+
                    "responseCode "+www.responseCode);
        }

    }
}