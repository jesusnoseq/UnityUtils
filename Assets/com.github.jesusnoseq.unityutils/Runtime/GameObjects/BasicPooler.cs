using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{

    public class BasicPooler<T> : MonoBehaviourSingleton<T> where T : Component
    {

        public GameObject prefab;
        public int pooledAmount = 20;
        public bool grow = true;

        List<GameObject> pooledObjects;

        // Use this for initialization
        void Start()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < pooledAmount; i++)
            {
                GameObject go = Instantiate(prefab, transform);
                go.SetActive(false);
                pooledObjects.Add(go);
            }

        }

        public GameObject GetPooledObject()
        {
            int n = pooledObjects.Count;
            for (int i = 0; i < n; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            if (grow)
            {
                GameObject go = Instantiate(prefab, transform);
                pooledObjects.Add(go);
                return go;
            }
            return null;
        }
    }
}