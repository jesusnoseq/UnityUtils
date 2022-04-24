using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



namespace com.jesusnoseq.util
{
    public class LoadLeaderBoardExample : MonoBehaviour
    {
        TMP_Text leaderboard;
        void Start()
        {
            var rac = GetComponent<RankClientAPI>();
            leaderboard= GetComponent<TMP_Text>();
            rac.GetPlayerRanks(HandleRankTableUpdate);
        }
        public void HandleRankTableUpdate(RankItem[] playerRanks)
        {
            leaderboard.text="";
            string table="Pos. \t Seconds \t Name \n";
            for (int i=0; i<playerRanks.Length; i++)
            {
                string seconds=string.Format("{0:0.00}",playerRanks[i].milliseconds/1000f);
                string line = $" {i+1} \t {seconds}  \t{playerRanks[i].name}\n";
                table=table+line;
            }
            leaderboard.text=""+table+"";
        }

    }
}
