using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundRecorder : MonoBehaviour
{
    private AudioSource audioSource;
    private Coroutine cor;

    public int maxSeconds = 5;
    public int frecuency = 44100;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void RecordAndPlay()
    {
        SafeCorutineStop(cor);
        cor =StartCoroutine(RecordAndPlayCor());
    }

    public void StopRecordingAndPlay()
    {
        SafeCorutineStop(cor);
        RecordEnd();
        Play();
    }

    private void SafeCorutineStop(Coroutine cor)
    {
        if (cor!=null)
        {
            StopCoroutine(cor);
        }
    }

    IEnumerator RecordAndPlayCor()
    {
        RecordStart();
        yield return new WaitForSecondsRealtime(maxSeconds);
        RecordEnd();
        Play();
    }

    // Start recording with built-in Microphone and play the recorded audio right away
    void RecordStart()
    {
        audioSource.clip = Microphone.Start("", false, maxSeconds, frecuency);
        Debug.Log("SoundRecorder mic start");
    }

    void RecordEnd()
    {
        Microphone.End("");
        Debug.Log("SoundRecorder mic end");
    }

    void Play()
    {
        Debug.Log("SoundRecorder play recording");
        audioSource.Play();
    }


     
}
