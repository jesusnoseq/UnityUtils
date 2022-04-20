using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;
using DG.Tweening;


public class BlinkText : MonoBehaviour {


    private void OnEnable()
    {
        GetComponent<Text>().DOFade(0f, 1.5f).SetEase(Ease.Flash, 14, 1);
    }

}
