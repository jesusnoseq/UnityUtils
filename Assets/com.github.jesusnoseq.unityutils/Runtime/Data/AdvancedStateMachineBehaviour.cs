using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{
    // from http://answers.unity3d.com/questions/1254566/is-there-a-way-to-get-a-statemachinebehaviour-on-a.html
    public class AdvancedStateMachineBehaviour : StateMachineBehaviour
    {
        protected AnimatorStateInfo stateInfo;

        public AnimatorStateInfo StateInfo
        {
            get { return stateInfo; }
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            this.stateInfo = stateInfo;
        }
    }
}