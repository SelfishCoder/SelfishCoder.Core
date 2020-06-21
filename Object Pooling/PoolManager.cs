using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace SelfishCoder.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        private Dictionary<GameObject,Pool> pools = new Dictionary<GameObject, Pool>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MenuItem("SelfishCoder/Core/Create Pool",false,1)]
        public static Pool CreatePool()
        {
            GameObject poolObject = new GameObject("New Pool");
            poolObject.transform.parent = GameObject.FindObjectOfType<PoolManager>().transform;
            
            Pool newPool = poolObject.AddComponent<Pool>();
            
            //Instance.pools.Add(basePrefab,newPool);
            return newPool;
        }
        
        public Pool CreatePool(GameObject basePrefab, int initialSize, int maxSize, bool isExtendable)
        {
            GameObject poolObject = new GameObject($"{basePrefab.name} Pool");
            poolObject.transform.parent = PoolManager.Instance.gameObject.transform;

            Pool newPool = poolObject.AddComponent<Pool>();
            
            pools.Add(basePrefab,newPool);
            return newPool;
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
                    InUse = false,
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
            if (pools.ContainsValue(pool))
            {
                pools.Remove(pool.Prefab);
            }
            Destroy(pool.gameObject);
        }
    }
}