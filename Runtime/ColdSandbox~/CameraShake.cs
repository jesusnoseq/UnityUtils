using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace com.jesusnoseq.util
{
public class CameraShake : MonoBehaviourSingleton<CameraShake> {
    public Camera cam;
    float shake = 0f;
    float shakeAmount = 0.5f;
    float decreaseFactor = 0.8f;
    //Vector3 orgPos;


    private void Start()
    {
        //orgPos = cam.transform.position;
    }


    void  Update()
    {
        if (shake > 0)
        {
            //Handheld.Vibrate();
            shake -= Time.unscaledDeltaTime * decreaseFactor;
            cam.transform.localPosition += Random.insideUnitSphere * shakeAmount;
        }
        /*else
        {
            shake = 0.0f;
            cam.transform.position = orgPos;
        }*/
    }
    public void SetShake(float shakeTime)
    {
        shake = shakeTime;
    }
}

}