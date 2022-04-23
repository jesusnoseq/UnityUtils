using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{
    public class InternetReadiness : MonoBehaviour, IReady
    {
        public string url = "http://clients3.google.com/generate_204";

        private bool pingSended;
        private bool pingOk;

        public bool IsReady()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                return false;
            }
            if (!pingSended)
            {
                pingSended = true;
                StartCoroutine(Ping());
            }
            return pingOk;
        }


        IEnumerator Ping()
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result==UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                pingOk = true;
            }
        }

    }
}