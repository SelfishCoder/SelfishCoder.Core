using System;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private bool used;

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
        public bool Used
        {
            get => used;
            set => used = value;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class PoolObject<T> where T : class
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private T component;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private bool used;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private int id;

        #endregion
    }
}