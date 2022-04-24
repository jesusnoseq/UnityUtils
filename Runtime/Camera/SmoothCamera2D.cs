using UnityEngine;
using System.Collections;

namespace com.jesusnoseq.util
{

    [RequireComponent(typeof(Camera))]
    public class SmoothCamera2D : MonoBehaviour
    {
        public Camera cam;
        public float dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;
        public Transform target;

        //Camera camera;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            if (target)
            {
                Vector3 point = cam.WorldToViewportPoint(target.position);
                Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }

        }
    }
}