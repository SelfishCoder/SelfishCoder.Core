using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace SelfishCoder.Core.SceneManagement
{
    /// <summary>
    /// 
    /// </summary>
    public static class SceneManager
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<AsyncOperation,Scene> asyncOperations = new Dictionary<AsyncOperation, Scene>();

        #endregion
        
        #region Events

        /// <summary>
        /// 
        /// </summary>
        public static event Action<Scene> SceneLoaded;
        
        /// <summary>
        /// 
        /// </summary>
        public static event Action<Scene> SceneUnloaded;
        
        /// <summary>
        /// 
        /// </summary>
        public static event Action<Scene> SceneReloaded;

        #endregion
        
        #region Loading Scene

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="sceneMode"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LoadScene(string sceneName, LoadSceneMode sceneMode = default)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, sceneMode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="sceneMode"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LoadScene(int sceneIndex, LoadSceneMode sceneMode = default)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex, sceneMode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="sceneMode"></param>
        public static void LoadSceneAsync(string sceneName, LoadSceneMode sceneMode = default)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            AsyncOperation loadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, sceneMode);
            loadOperation.completed += OnSceneLoadedAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="sceneMode"></param>
        public static void LoadSceneAsync(int sceneIndex, LoadSceneMode sceneMode = default)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            AsyncOperation loadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, sceneMode);
            loadOperation.completed += OnSceneLoadedAsync;
        }

        #endregion

        #region Unloading Scene

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="unloadOptions"></param>
        public static void UnloadSceneAsync(string sceneName, UnloadSceneOptions unloadOptions = default)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            AsyncOperation unloadOperation = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName, unloadOptions);
            unloadOperation.completed += OnSceneUnloadedAsync;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="unloadOptions"></param>
        public static void UnloadSceneAsync(int sceneIndex, UnloadSceneOptions unloadOptions = default)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            AsyncOperation unloadOperation = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex, unloadOptions);
            unloadOperation.completed += OnSceneUnloadedAsync;
        }

        #endregion

        #region SceneUtility
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        public static bool IsCurrentScene(string sceneName)
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals(sceneName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <returns></returns>
        public static bool IsCurrentScene(int sceneIndex)
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex.Equals(sceneIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        private static bool IsSceneExist(string sceneName)
        {
            return EditorBuildSettings.scenes.Any(scene => scene.path.Contains(sceneName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <returns></returns>
        private static bool IsSceneExist(int sceneIndex)
        {
            return sceneIndex >= 0 && EditorBuildSettings.scenes.Length >= sceneIndex;
        }
        
        #endregion

        #region Event Raising Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        private static void OnSceneLoaded(Scene scene)
        {
            SceneLoaded?.Invoke(scene);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        private static void OnSceneUnloaded(Scene scene)
        {
            SceneUnloaded?.Invoke(scene);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unloadOperation"></param>
        private static void OnSceneLoadedAsync(AsyncOperation unloadOperation)
        {
            if (!asyncOperations.ContainsKey(unloadOperation)) return;
            OnSceneLoaded(asyncOperations[unloadOperation]);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unloadOperation"></param>
        private static void OnSceneUnloadedAsync(AsyncOperation unloadOperation)
        {
            if (!asyncOperations.ContainsKey(unloadOperation)) return;
            OnSceneUnloaded(asyncOperations[unloadOperation]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scene"></param>
        private static void OnSceneReloaded(Scene scene)
        {
            SceneReloaded?.Invoke(scene);
        }
        
        #endregion
    }
}