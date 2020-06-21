using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelfishCoder.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class SceneManager
    {
        #region Loading Scene

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LoadScene(string sceneName)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="sceneMode"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LoadScene(string sceneName, LoadSceneMode sceneMode)
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LoadScene(int sceneIndex)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="sceneMode"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void LoadScene(int sceneIndex, LoadSceneMode sceneMode)
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
        public static void LoadSceneAsync(string sceneName)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="sceneMode"></param>
        public static void LoadSceneAsync(string sceneName, LoadSceneMode sceneMode)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            AsyncOperation asyncOperation =
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, sceneMode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        public static void LoadSceneAsync(int sceneIndex)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="sceneMode"></param>
        public static void LoadSceneAsync(int sceneIndex, LoadSceneMode sceneMode)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            AsyncOperation asyncOperation =
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex, sceneMode);
        }

        #endregion

        #region Unloading Scene

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        public static void UnloadSceneAsync(string sceneName)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="unloadOptions"></param>
        public static void UnloadSceneAsync(string sceneName, UnloadSceneOptions unloadOptions)
        {
            if (!IsSceneExist(sceneName))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneName),
                    $"Scene Name: '{sceneName}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName, unloadOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        public static void UnloadSceneAsync(int sceneIndex)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sceneIndex"></param>
        /// <param name="unloadOptions"></param>
        public static void UnloadSceneAsync(int sceneIndex, UnloadSceneOptions unloadOptions)
        {
            if (!IsSceneExist(sceneIndex))
            {
                throw new ArgumentOutOfRangeException(nameof(sceneIndex),
                    $"Scene Index: '{sceneIndex}' is not valid in the current context.");
            }

            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneIndex, unloadOptions);
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
    }
}