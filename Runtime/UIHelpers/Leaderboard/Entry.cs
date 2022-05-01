using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace com.jesusnoseq.util
{
    [RequireComponent(typeof(Image))]
    public class Entry : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text positionText;
        [SerializeField]
        private TMP_Text nameText;
        [SerializeField]
        private TMP_Text scoreText;

        [SerializeField]
        private Color OddColor;
        [SerializeField]
        private Color EvenColor;

        public void SetValues(int position, string name, string score){
            positionText.text=position.ToString();
            nameText.text=name;
            scoreText.text=score;
            Image panel = GetComponent<Image>();
            panel.color= (position%2==0)? EvenColor : OddColor;
        }
    }
}