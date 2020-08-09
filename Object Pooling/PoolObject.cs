using System;
using UnityEngine;

namespace SelfishCoder.Core
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PoolObject
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private GameObject gameObject;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private bool inUse;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int id;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public GameObject GameObject
        {
            get => gameObject;
            set => gameObject = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool InUse
        {
            get => inUse;
            set => inUse = value;
        }

        #endregion
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class PoolObject<T> where T: class
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private T component;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private bool inUse;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int id;

        #endregion
    }
}