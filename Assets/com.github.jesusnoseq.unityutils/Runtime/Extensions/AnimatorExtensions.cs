using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public static class AnimatorExtensions {

        // StateMachineBehaviour on a specific State
        //  Source http://answers.unity3d.com/questions/1254566/is-there-a-way-to-get-a-statemachinebehaviour-on-a.html
        public static T GetBehaviour<T>(this Animator animator, AnimatorStateInfo stateInfo) where T : AdvancedStateMachineBehaviour
        {
            return animator.GetBehaviours<T>().ToList().First(behaviour => behaviour.StateInfo.fullPathHash == stateInfo.fullPathHash);
        }

        public static bool IsPlaying(this Animator animator, int layer = 0)
        {

            return animator.GetCurrentAnimatorStateInfo(layer).length >
                   animator.GetCurrentAnimatorStateInfo(layer).normalizedTime;
        }

        public static bool IsPlaying(this Animator animator, string stateName, int layer = 0)
        {
            return animator.IsPlaying() && animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName);
        }
    }
}
