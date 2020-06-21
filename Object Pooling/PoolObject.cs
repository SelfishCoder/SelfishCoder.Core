using System;
using UnityEngine;

namespace SelfishCoder.Core
{
    [Serializable]
    public class PoolObject
    {
        [SerializeField] private GameObject gameObject;
        [SerializeField] private bool inUse;
        [SerializeField] private int id;

        public GameObject GameObject
        {
            get => gameObject;
            set => gameObject = value;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public bool InUse
        {
            get => inUse;
            set => inUse = value;
        }
    }
    
    [Serializable]
    public class PoolObject<T> where T: class
    {
        [SerializeField] private T component;
        [SerializeField] private bool inUse;
        [SerializeField] private int id;
    }
}