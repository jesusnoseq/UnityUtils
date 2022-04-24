using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
public class GoogleDriveCSVDownloader : MonoBehaviour {
        // where can i generate a new api key
        // https://console.developers.google.com/apis/credentials

        //Example url
        //https://sheets.googleapis.com/v4/spreadsheets/1lTp-PPG68lo84qTD0nARNzYLKeGa-Z7As5VYBzek0R8/values/test?key=AIzaSyCLtq61qOAOa7UXRgVqsozyTVKHD0BeiVY
        public string sheetName = "Hoja 1";
        public string APIKey= "AIzaSyCLtq61qOAOa7UXRgVqsozyTVKHD0BeiVY";
        public string documendID = "1lTp-PPG68lo84qTD0nARNzYLKeGa-Z7As5VYBzek0R8";

        const string API_URL = "https://sheets.googleapis.com/v4/spreadsheets/{0}/values/{1}?key={2}";

        // Use this for initialization
        void Start () {
            //StartCoroutine(downloadCSV());
        }
        
        /*IEnumerator DownloadCSV()
        {
            string apiCallURL = String.Format(API_URL, documendID, sheetName, APIKey);
            Debug.Log(apiCallURL);
            WWW www = new WWW(apiCallURL);
            yield return www;

            yield return www;
            if (www.error == null)
            {
                //Debug.Log(www.text);
                CSVData data = JsonUtility.FromJson<CSVData>(www.text);
                Debug.Log(data);
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
        }*/
    }
}