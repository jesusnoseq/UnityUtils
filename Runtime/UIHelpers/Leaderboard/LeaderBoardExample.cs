using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class LeaderBoardExample : MonoBehaviour
    {
        public Leaderboard lb;
        public LeaderboardForm lbForm;

        private RankClientAPI client;

        int score=999;

        public void Start()
        {
            client = GetComponent<RankClientAPI>();
            client.GetPlayerRanks(HandleLeaderboardUpdate);
            lbForm.SetScore(score);
        }


        public void HandleLeaderboardUpdate(RankItem[] playerRanks)
        {
            for (int i=0; i<playerRanks.Length; i++)
            {
                RankItem ri= playerRanks[i];
                lb.AddNewEntry(i+1, ri.name, ri.milliseconds.ToString());
            }
        }

        public void SendScore(){
            //lbForm.DisableForm();
            name= lbForm.GetName();
            client.PostRanks(name, score, HandlePostScore);
        }

        public void HandlePostScore(string postInfo){
            client.GetPlayerRanks(HandleLeaderboardUpdate);
            Debug.Log("Post sent");
        }

    }
}