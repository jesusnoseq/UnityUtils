using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{
    public delegate void AnimationEndCallback();

    public class MenuPanel : MonoBehaviour
    {
        public bool isPopUp;

        protected MenuManager parentMM;
        protected bool disableOnHide;
        protected IMenuAnimation anim;

        protected virtual void Start()
        {
            anim=gameObject.GetInterface<IMenuAnimation>();
        }

        public void SetMenuManager(MenuManager menuManager)
        {
            parentMM = menuManager;
            disableOnHide = menuManager.disableOnHide;
        }

        public virtual void OnBackButtonPressed()
        {
            parentMM.OnBackButtonPressed();
        }
        
        public virtual void Show()
        {
            if (anim != null)
            {
                anim.Play(new AnimationEndCallback(OnShow));
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

        protected virtual void OnShow()
        {

        }

        public virtual void Hide(bool disable=true)
        {
            disableOnHide = disable;
            if (anim != null)
            {
                anim.PlayBack(new AnimationEndCallback(OnHide));
            }
            else
            {
                gameObject.SetActive(!(disableOnHide || isPopUp));
            }

            if (isPopUp)
            {

            }
        }

        protected virtual void OnHide()
        {
            if (disableOnHide || isPopUp)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
