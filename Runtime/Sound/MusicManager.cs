using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace com.jesusnoseq.util
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviourSingletonPersistent<MusicManager> {
        AudioSource audioSource;
        public AudioClip loopeableMusic;
        // Use this for initialization
        void Start () {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = loopeableMusic;
                audioSource.loop = true;
                audioSource.Play();
            }
        }


        }
}
