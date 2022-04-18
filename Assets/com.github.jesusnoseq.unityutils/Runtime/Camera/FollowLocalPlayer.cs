using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace com.jesusnoseq.util
{

[RequireComponent(typeof(Camera))]
public class FollowLocalPlayer : MonoBehaviourSingleton<FollowLocalPlayer> {

    Transform playerTransform;
    private float yPos;
    private float xOffset;

    private void Start()
    {
        yPos = transform.position.y;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = new Vector3(playerTransform.position.x- xOffset, yPos, transform.position.z);
        }
    }

    public void SetTarget(Transform target)
    {
        
        playerTransform = target;
        xOffset = playerTransform.position.x - transform.position.x;
    }

    public void Shake(float time=0.5f, float force=1f)
    {
        transform.DOShakePosition(time, force);
    }
}

}