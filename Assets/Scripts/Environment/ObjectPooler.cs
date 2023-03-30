namespace RoyGBiv.Environment {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField]
        private GameObject pooledObject = null;

        [SerializeField]
        private int pooledAmount = 0;

        List<GameObject> pooledObjects;

        void Start() {
            pooledObjects = new List<GameObject>();

            for (int i = 0; i < pooledAmount; i++)
            {
                GameObject obj = Instantiate(pooledObject);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        public GameObject GetPooledObject()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }
    }

 
}