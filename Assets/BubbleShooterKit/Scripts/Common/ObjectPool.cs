using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace SimForge.Games.BubbleShooter.Blaze
{



    public class ObjectPool : MonoBehaviour
    {
        public GameObject Prefab;
        public int InitialSize;

        readonly Queue<GameObject> instances = new Queue<GameObject>();

        void Awake()
        {
            Assert.IsNotNull(Prefab);
        }

        public void Initialize()
        {
            for (var i = 0; i < InitialSize; i++)
            {
                var obj = CreateInstance();
                obj.SetActive(false);
                instances.Enqueue(obj);
            }
        }

        public GameObject GetObject()
        {
            var obj = instances.Count > 0 ? instances.Dequeue() : CreateInstance();
            obj.SetActive(true);
            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            var pooledObject = obj.GetComponent<PooledObject>();
            Assert.IsNotNull(pooledObject);
            Assert.IsTrue(pooledObject.Pool == this);

            obj.SetActive(false);
            if (!instances.Contains(obj))
                instances.Enqueue(obj);
        }

        public void Reset()
        {
            var objectsToReturn = new List<GameObject>();
            foreach (var instance in transform.GetComponentsInChildren<PooledObject>())
            {
                if (instance.gameObject.activeSelf)
                    objectsToReturn.Add(instance.gameObject);
            }
            
            foreach (var instance in objectsToReturn)
                ReturnObject(instance);
        }

        GameObject CreateInstance()
        {
            var obj = Instantiate(Prefab);
            var pooledObject = obj.AddComponent<PooledObject>();
            pooledObject.Pool = this;
            obj.transform.SetParent(transform);
            return obj;
        }
    }

    public class PooledObject : MonoBehaviour
    {
        public ObjectPool Pool;
    }
}
