using UnityEngine;
using System.Text;



namespace com.jesusnoseq.util
{
    public delegate void OnPlayerRanksGetCompleteCallBack(RankItem[] playerRanks);
    public delegate void OnPlayerRanksSendCompleteCallBack(string result);

    [RequireComponent(typeof(RequestManager))]
    public class RankClientAPI : MonoBehaviour
    {
        private RequestManager requestManager;
        private string endPointURL=RankApiClientConfig.endPointURL;
        private string salt=RankApiClientConfig.salt;

        public void GetPlayerRanks(OnPlayerRanksGetCompleteCallBack callback)
        {
            requestManager = GetComponent<RequestManager>();
            requestManager.Get(endPointURL, (result) => {
                RankItem[] ranks = JsonHelper.FromJson<RankItem>(result);
                callback(ranks);
            });
        }

        public void PostRanks(string name, int score, OnPlayerRanksSendCompleteCallBack callback=null)
        {
            requestManager = GetComponent<RequestManager>();
            RankItem rank = new RankItem(name, score);
            rank.hash = Hasher.SHA256(name + score + salt, Encoding.UTF8);

            string jsonData = JsonUtility.ToJson(rank);

            requestManager.Post(endPointURL, jsonData, (result) => {
                if(callback != null){
                    callback(result);
                }else{
                    Debug.Log(endPointURL);
                    Debug.Log(jsonData);
                    Debug.Log(result);
                }
            });
        }
    }
}