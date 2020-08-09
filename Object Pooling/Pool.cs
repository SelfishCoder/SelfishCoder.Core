using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace SelfishCoder.Core
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, DisallowMultipleComponent]
    public class Pool : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private GameObject prefab = null;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int initialSize = 0;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int currentSize = 0;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int maxSize = 0;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private bool isExtendable = false;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private List<PoolObject> objects = new List<PoolObject>();

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public GameObject Prefab
        {
            get => prefab;
            private set => prefab = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int InitialSize
        {
            get => initialSize;
            private set => initialSize = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CurrentSize
        {
            get => currentSize;
            private set => currentSize = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int MaxSize
        {
            get => maxSize;
            private set => maxSize = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsExtendable
        {
            get => isExtendable;
            private set => isExtendable = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<PoolObject> Objects
        {
            get => objects;
            set => objects = value;
        }

        #endregion
        
        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="initialSize"></param>
        /// <param name="maxSize"></param>
        /// <param name="isExtendable"></param>
        public Pool(GameObject prefab, int initialSize = 10, int maxSize = 10, bool isExtendable = false)
        {
            this.Prefab = prefab;
            this.InitialSize = initialSize;
            this.MaxSize = maxSize;
            this.IsExtendable = isExtendable;
        }
        
        #endregion
        
        #region Events

        /// <summary>
        /// 
        /// </summary>
        [Space(10f),Header("Events")]
        [SerializeField] private UnityEvent onPoolCreated;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private UnityEvent onPoolSizeChanged;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private UnityEvent onPoolInitialized;

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PoolObject GetObject()
        {
            foreach (PoolObject poolObject in this.Objects)
            {
                if (!poolObject.InUse && !poolObject.GameObject.activeInHierarchy)
                {
                    poolObject.InUse = true;
                    poolObject.GameObject.SetActive(true);
                    return poolObject;
                }
            }
            return null;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Pool<T> : MonoBehaviour where T : class
    {
        [SerializeField] private int initialSize;
        [SerializeField] private int currentSize;
        [SerializeField] private int maxSize;
        [SerializeField] private bool isExtendable;
        [Space(10f), SerializeField] private UnityEvent onPoolObjectConsumed;
        [SerializeField] private UnityEvent onPoolObjectRecycled;
        [SerializeField] private UnityEvent onPoolObjectSpawned;
        [SerializeField] private UnityEvent onPoolCreated;
        [SerializeField] private UnityEvent onPoolExtended;
        [SerializeField] private UnityEvent onPoolShrinked;
        [SerializeField] private UnityEvent onPoolInitialized;
        private List<PoolObject<T>> poolObjects;
    }
}