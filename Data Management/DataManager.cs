using System.IO;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SelfishCoder.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool ExistsAtPersistentDataPath(string fileName)
        {
            return Exists($"{Application.persistentDataPath}/{fileName}.dat");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileName"></param>
        /// <param name="fileMode"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="SerializationException"></exception>
        private static void Save<T>(T data, string fileName, FileMode fileMode = FileMode.Create)
        {
            string path = $"{Application.persistentDataPath}/Saves/{fileName}.dat";
            Directory.CreateDirectory(path);
            FileStream fileStream = new FileStream(path, fileMode);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(fileStream, data);
            }
            catch (SerializationException exception)
            {
                throw new SerializationException("Save failed. Error: " + exception.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        public static T Load<T>(string fileName)
        {
            string path = $"{Application.persistentDataPath}/Saves/{fileName}.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            T load;
            try
            {
                load = (T)formatter.Deserialize(fileStream);
            }
            catch (SerializationException exception)
            {
                throw new SerializationException($"Load failed. Error: {exception.Message}");
            }
            finally
            {
                fileStream.Close();
            }
            return load;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteSave(string fileName)
        {
            if (!ExistsAtPersistentDataPath(fileName)) return;
            string path = $"{Application.persistentDataPath}/Saves/{fileName}.dat";
            File.Delete(path);
        }
    }
}