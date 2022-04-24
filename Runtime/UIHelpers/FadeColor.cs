using UnityEngine;
using DG.Tweening;

namespace com.jesusnoseq.util
{
    public class FadeColor : MonoBehaviour {
        public SpriteRenderer sprite;

        public float fadeSeconds=0.5f;
        [Range(0f, 1.0f)]
        public float fadeFrom = 0.5f;
        [Range(0f, 1.0f)]
        public float fadeTo = 0.2f;

        private bool fading;
        private bool fadingIn;

        void Start () {
            fadingIn = true;
        }
        
        void Update () {
            if (fadingIn && !fading)
            {
                fading = true;
                sprite.DOFade(fadeTo, fadeSeconds).OnComplete(() => { fading = false; fadingIn = false; });
            }
            else if(!fading)
            {
                fading = true;
                sprite.DOFade(fadeFrom, fadeSeconds).OnComplete(()=> { fading = false; fadingIn = true; });
            }
        }
    }

}