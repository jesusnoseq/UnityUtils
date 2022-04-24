using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public interface IMenuAnimation
    {
        void Play(AnimationEndCallback callback);

        void PlayBack(AnimationEndCallback callback);
    }
}