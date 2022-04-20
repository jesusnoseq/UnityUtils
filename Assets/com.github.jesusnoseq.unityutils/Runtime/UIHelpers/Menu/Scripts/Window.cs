using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace com.jesusnoseq.util
{
    public class Window : MonoBehaviour {

        public bool isPopUp;
        Animator anim;

        private const string ANIM_SHOW_TGR = "show";
        private const string ANIM_HIDE_TGR = "hide";

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void OnShow()
        {
            if (anim!=null)
            {
                anim.SetTrigger(ANIM_SHOW_TGR);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        public void OnHide()
        {
            if (anim != null)
            {
                anim.SetTrigger(ANIM_HIDE_TGR);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

}