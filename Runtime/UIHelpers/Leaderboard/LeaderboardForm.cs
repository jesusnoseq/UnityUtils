using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace com.jesusnoseq.util
{
    public class LeaderboardForm : MonoBehaviour
    { 

        [SerializeField]
        private TMP_Text scoreText;
        [SerializeField]
        private TMP_InputField nameInput;

        [SerializeField]
        private Button sendButton;

        private int score;

        public void SetScore(int score){
            scoreText.text="Score: "+score.ToString();
        }

        public string GetName(){
            return  nameInput.text;
        }

        public void DisableForm(){
            nameInput.readOnly=true;
            sendButton.interactable = false;
        }

    }
}