using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{

    [RequireComponent(typeof(Animator))]
    public class MenuAnimationUnBasic : MonoBehaviour, IMenuAnimation
    {
        private Animator anim;

        private Coroutine animCoroutine;
        private const string ANIM_SHOW_TGR = "Show";
        private const string ANIM_HIDE_TGR = "Hide";

        public UnityEvent onAnimationEnd;

        protected virtual void Start()
        {
            anim = GetComponent<Animator>();
        }

        public virtual void Play(AnimationEndCallback callback)
        {
            if (animCoroutine != null)
            {
                StopCoroutine(animCoroutine);
                //Debug.Log("Stop to show cor " + gameObject.name);
            }
            gameObject.SetActive(true);
            animCoroutine = StartCoroutine(PlayAnimCor(ANIM_SHOW_TGR, callback));
        }


        public virtual void PlayBack(AnimationEndCallback callback)
        {
            if (animCoroutine != null)
            {
                StopCoroutine(animCoroutine);
                //Debug.Log("Stop to hide cor "+gameObject.name);
            }
            animCoroutine = StartCoroutine(PlayAnimCor(ANIM_HIDE_TGR, callback));
        }

        protected IEnumerator PlayAnimCor(string trigger, AnimationEndCallback callback)
        {
            //Debug.Log("Iniciando cor "+ trigger+"  en "+gameObject.name);
            anim.SetTrigger(trigger);
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

            callback?.Invoke();
            onAnimationEnd.Invoke();
        }
    }
}