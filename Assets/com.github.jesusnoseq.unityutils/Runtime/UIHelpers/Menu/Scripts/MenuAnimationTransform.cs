using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using System;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{
    public class MenuAnimationTransform : MonoBehaviour, IMenuAnimation
    {
        public Vector3 posTarget;
        public Vector3 scaleTarget;
        public Vector3 rotationTarget;
        public float delay = 0;
        public float time = 0.2f;
        public Ease easeFuncion = Ease.Linear;
        
        public UnityEvent onAnimationEnd;

        protected Sequence seq;
        protected Tweener twe;



        void Reset()
        {
            posTarget = transform.position;
            scaleTarget = transform.localScale;
            rotationTarget = transform.rotation.eulerAngles;
        }


        protected virtual void Start()
        {
            if (onAnimationEnd == null)
                onAnimationEnd = new UnityEvent();

            seq = DOTween.Sequence()
                .SetDelay(delay)
                .Join(transform.DOMove(posTarget, time, false))
                .Join(transform.DOScale(scaleTarget, time))
                .Join(transform.DORotate(rotationTarget, time))
                .SetEase(easeFuncion)
                .SetAutoKill(false).SetRecyclable(true).Pause();
        }




        public void Play(AnimationEndCallback callback = null)
        {
            if (!seq.IsComplete())
            {
                seq.Restart();
                seq.Play();

                seq.OnComplete(() => {
                    if (callback != null)
                    {
                        callback();
                    }
                    onAnimationEnd.Invoke();
                });
                
            }
        }

        public void Play()
        {
            Play();
        }

        public void PlayBack()
        {
            PlayBack();
        }

        public void PlayBack(AnimationEndCallback callback = null)
        {
            if (!seq.isBackwards)
            {
                seq.Complete();
            }

            if (seq.IsComplete())
            {
                seq.PlayBackwards();

                seq.OnRewind(() => {
                    if (callback != null)
                    {
                        callback();
                    }
                    onAnimationEnd.Invoke();
                });
                
            }
        }
    }
}