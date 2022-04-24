using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{

    [ExecuteInEditMode]
    public class SlowMotion : MonoBehaviour
    {

        [SerializeField]
        [Range(0, 3)]
        public float timeScale;

        // Use this for initialization
        void Start()
        {
            timeScale = Time.timeScale;
        }

        // Update is called once per frame
        void Update()
        {
            timeScale = Time.timeScale;
        }


        void OnValidate()
        {
            Time.timeScale = timeScale;
        }
    }

}
