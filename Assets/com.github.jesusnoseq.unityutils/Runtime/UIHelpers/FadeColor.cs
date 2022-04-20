using UnityEngine;
using DG.Tweening;

namespace com.jesusnoseq.util
{
    public class FadeColor : MonoBehaviour {
        public SpriteRenderer sprite;
        private bool fading;
        private bool fadingIn;

        void Start () {
            fadingIn = true;
        }
        
        void Update () {
            if (fadingIn && !fading)
            {
                fading = true;
                sprite.DOFade(0.2f, 0.5f).OnComplete(() => { fading = false; fadingIn = false; });
            }
            else if(!fading)
            {
                fading = true;
                sprite.DOFade(0.5f, 0.5f).OnComplete(()=> { fading = false; fadingIn = true; });
            }
        }
    }

}