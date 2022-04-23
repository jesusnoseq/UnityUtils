using UnityEngine;
using DG;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class BlinkText : MonoBehaviour {
    public float seconds=1.5f;
    public int times = 14;

    [Range(-1.0f, 1.0f)]
    public float initialForce = 0f;

    public Ease easeMode = Ease.Flash;


    private void OnEnable()
    {
        GetComponent<TMP_Text>().DOFade(0f,seconds).SetEase(easeMode, times, initialForce);
    }

}
