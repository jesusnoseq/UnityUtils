using UnityEngine;
using System.Text;



namespace com.jesusnoseq.util
{
    public delegate void OnPlayerRanksCompleteCallBack(RankItem[] playerRanks);

    [RequireComponent(typeof(RequestManager))]
    public class RankClientAPI : MonoBehaviour
    {
        private RequestManager requestManager;
        [SerializeField]
        private string endPointURL=RankApiClientConfig.endPointURL;
        [SerializeField]
        private string salt=RankApiClientConfig.salt;

        public void GetPlayerRanks(OnPlayerRanksCompleteCallBack callback)
        {
            requestManager = GetComponent<RequestManager>();
            requestManager.Get(endPointURL, (result) => {
                RankItem[] ranks = JsonHelper.FromJson<RankItem>(result);
                callback(ranks);
            });
        }

        public void PostRanks(string name, int score)
        {
            requestManager = GetComponent<RequestManager>();
            RankItem rank = new RankItem(name, score);
            rank.hash = Hasher.SHA256(name + score + salt, Encoding.UTF8);

            string jsonData = JsonUtility.ToJson(rank);

            requestManager.Post(endPointURL, jsonData, (result) => {
                Debug.Log("Result: "+ result);
            });
        }
    }
}