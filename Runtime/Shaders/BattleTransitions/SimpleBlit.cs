using UnityEngine;
using System.Collections;


namespace com.jesusnoseq.util
{
    [ExecuteInEditMode]
    public class SimpleBlit : MonoBehaviour
    {
        public Material TransitionMaterial;

        void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            if (TransitionMaterial != null)
                Graphics.Blit(src, dst, TransitionMaterial);
        }
    }
}