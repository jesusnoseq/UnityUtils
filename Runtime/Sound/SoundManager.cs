using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System;

namespace com.jesusnoseq.util
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
        public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
        public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
        public float pitchOffset=0;
        public bool playOnEnable = false;

        private float defaultPitch;

        private void Start()
        {
            if (efxSource==null)
            {
                efxSource = GetComponent<AudioSource>();
            }
            defaultPitch = efxSource.pitch;
        }

        private void OnEnable()
        {
            if (playOnEnable)
            {
                efxSource.Play();
            }
        }




        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip)
        {
            efxSource.pitch = defaultPitch;
            efxSource.clip = clip;
            efxSource.Play();
        }



        public void PlayRandomizeSfx(AudioClip clip){
            float randomPitch = pitchOffset + UnityEngine.Random.Range(lowPitchRange, highPitchRange);
            efxSource.pitch = randomPitch;
            efxSource.clip = clip;

            efxSource.Play();
        }

        //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
        public void PlayRandomizeSfx(params AudioClip[] clips)
        {
            //Generate a random number between 0 and the length of our array of clips passed in.
            int randomIndex = UnityEngine.Random.Range(0, clips.Length);
            PlayRandomizeSfx(clips[randomIndex]);
        }


        public AudioClip GetLastSound()
        {
            return efxSource.clip;
        }
    }

}