using System;
using UnityEngine;
using System.Collections.Generic;

namespace SelfishCoder.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<GameObject,Pool> pools = new Dictionary<GameObject, Pool>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<GameObject, Pool> Pools => pools;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pool"></param>
        public void AddPool(Pool pool)
        {
            pools.Add(pool.Prefab,pool);    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pool"></param>
        public void RemovePool(Pool pool)
        {
            if (pools.ContainsValue(pool))
            {
                pools.Remove(pool.Prefab);
            }
        }

        public Pool GetPool()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Pool CreatePool()
        {
            Pool pool =  new GameObject("New Pool").AddComponent<Pool>();
            GameObject parent = GameObject.Find("Pools");
            Transform parentTransform = parent ? parent.transform : new GameObject("Pools").transform;
            pool.transform.parent = parentTransform.transform;
            return pool;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePrefab"></param>
        /// <param name="initialSize"></param>
        /// <param name="maxSize"></param>
        /// <param name="isExtendable"></param>
        /// <returns></returns>
        public Pool CreatePool(GameObject basePrefab, int initialSize, int maxSize, bool isExtendable)
        {
            Pool pool = new GameObject($"{basePrefab.name} Pool").AddComponent<Pool>();
            GameObject parent = GameObject.Find("Pools");
            Transform parentTransform = parent ? parent.transform : new GameObject("Pools").transform;
            pool.transform.parent = parentTransform.transform;
            return pool;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pool"></param>
        /// <returns></returns>
        public Pool InitializePool(Pool pool)
        {
            for (int i = 0; i < pool.InitialSize; i++)
            {
                PoolObject poolObject = new PoolObject
                {
                    GameObject = Instantiate(pool.Prefab),
                    Used = false,
                    Id = i
                };
                poolObject.GameObject.SetActive(false);
                poolObject.GameObject.transform.SetParent(pool.gameObject.transform);
                pool.Objects.Add(poolObject);
            }
            return pool;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pool"></param>
        public void DestroyPool(Pool pool)
        {
            RemovePool(pool);
            Destroy(pool.gameObject);
        }
    }
}