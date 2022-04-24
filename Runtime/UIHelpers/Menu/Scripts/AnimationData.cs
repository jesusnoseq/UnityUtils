using UnityEngine;
using DG;
using DG.Tweening;


namespace com.jesusnoseq.util
{
    [CreateAssetMenu(fileName = "AnimationData", menuName = "Utils/Menu/Animation", order = 1)]
    public class AnimationData : ScriptableObject
    {
        public Vector2 anchorMintarget=Vector2.zero;
        public Vector2 anchorMaxtarget=Vector2.one;
        public Vector3 scale=Vector3.one;
        public Vector3 rotation=Vector3.zero;
        public float delay=0;
        public float animationTime=0.25f;
        public Ease easeFuncion= Ease.Linear;
    }
}