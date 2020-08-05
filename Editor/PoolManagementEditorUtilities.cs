using UnityEditor;
using UnityEngine;

namespace SelfishCoder.Core.Editor
{
    /// <summary>
    /// 
    /// </summary>
    public static class PoolManagementEditorUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        [MenuItem("SelfishCoder/Core/Create/Pool Manager",false,1)]
        public static void CreatePoolManager()
        {
            if (GameObject.FindObjectOfType<PoolManager>())
            {
                Debug.LogWarning("There is a Pool Manager in the current context.");
                return;
            }
            new GameObject("Pool Manager").AddComponent<PoolManager>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        [MenuItem("SelfishCoder/Core/Create/Pool",false,2)]
        public static void CreatePool()
        {
            PoolManager poolManager = GameObject.FindObjectOfType<PoolManager>();
            if (!poolManager)
            {
                Debug.LogError("There is not Pool Manager in the current context. Please create a Pool Manager before creating a pool.");
                return;
            }
            GameObject poolGameObject = new GameObject("New Pool");
            Pool pool = poolGameObject.AddComponent<Pool>();
            GameObject parent = GameObject.Find("Pools");
            Transform parentTransform = parent ? parent.transform : new GameObject("Pools").transform;
            poolGameObject.transform.parent = parentTransform.transform;
        }
    }
}