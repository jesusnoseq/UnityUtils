using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{

    [RequireComponent(typeof(LineRenderer))]
    public class GunLaser : MonoBehaviour {

        private LineRenderer line;

        [SerializeField]
        private float laserDistance = 5f;


        [SerializeField]
        private bool laser2D = false;

        // Use this for initialization
        void Start () {
            line = gameObject.GetComponent<LineRenderer>();
        }
        
        // Update is called once per frame
        void Update () {
            if (laser2D)
            {
                FireLaser2D();
            }else
            {
                FireLaser();
            }
            
        }


        public void FireLaser2D()
        {

            Ray2D ray = new Ray2D(transform.position, transform.right);
            RaycastHit2D hit;

            line.SetPosition(0, ray.origin);

            hit = Physics2D.Raycast(ray.origin, Vector2.right, laserDistance);

            if (hit.collider)
            {
                line.SetPosition(1, hit.point);
            }
            else
                line.SetPosition(1, ray.GetPoint(laserDistance));
        }

        private void FireLaser()
        {
            Ray ray = new Ray(transform.position, transform.right);
            RaycastHit hit;
            line.SetPosition(0, ray.origin);
            if (Physics.Raycast(ray, out hit, laserDistance))
            {
                line.SetPosition(1, hit.point);
            }
            else
            {
                line.SetPosition(1, ray.GetPoint(laserDistance));
            }
        }
    }


}