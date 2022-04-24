using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundRecorderButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SoundRecorder sr;

    public void OnPointerDown(PointerEventData eventData)
    {
        sr.RecordAndPlay();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        sr.StopRecordingAndPlay();
    }
}
