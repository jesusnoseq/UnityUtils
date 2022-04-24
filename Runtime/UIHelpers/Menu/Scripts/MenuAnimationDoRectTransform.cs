using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using UnityEngine.Events;

namespace com.jesusnoseq.util
{
    public class MenuAnimationDoRectTransform : MonoBehaviour, IMenuAnimation
    {
        public Vector2 anchorMaxtarget;
        public Vector2 anchorMintarget;
        public Vector3 scaleTarget;
        public Vector3 rotationTarget;
        public float delay = 0;
        public float time=0.2f;
        public Ease easeFuncion = Ease.Linear;

        public UnityEvent onAnimationEnd;

        protected RectTransform rect;
        protected Sequence seq;
        protected Tweener twe;


        void Reset()
        {
            rect = GetComponent<RectTransform>();
            anchorMaxtarget = rect.anchorMax;
            anchorMintarget = rect.anchorMin;
            scaleTarget = rect.localScale;
            rotationTarget = rect.rotation.eulerAngles;
        }


        protected virtual void Start()
        {
            rect = GetComponent<RectTransform>();
    
            seq = DOTween.Sequence()
                .SetDelay(delay)
                .Join(rect.DOAnchorMax(anchorMaxtarget, time, false))
                .Join(rect.DOAnchorMin(anchorMintarget, time, false))
                .Join(rect.DOScale(scaleTarget, time))
                .Join(rect.DORotate(rotationTarget, time))
                .SetEase(easeFuncion)
                .SetAutoKill(false).SetRecyclable(true).Pause();
        }




       public void Play(AnimationEndCallback callback=null)
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
            Play(null);
        }

        public void PlayBack()
        {
            PlayBack(null);
        }

        public void PlayBack(AnimationEndCallback callback=null)
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