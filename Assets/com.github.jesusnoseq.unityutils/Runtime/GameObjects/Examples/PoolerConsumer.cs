using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{

    public class PoolerConsumer : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(MouseClick.LeftClick()){
                Vector3 pos=MousePosition.Get();
                pos.z = Camera.main.nearClipPlane;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pos);
                GameObject go=SpriteRendererPooler.Instance.GetPooledObject();
                go.transform.position=worldPosition;
                go.SetActive(true);
            }
        }
    }

}
