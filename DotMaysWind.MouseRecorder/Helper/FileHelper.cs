using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotMaysWind.MouseRecorder.Helper
{
    /// <summary>
    /// 文件序列化辅助类
    /// </summary>
    internal static class FileHelper
    {
        /// <summary>
        /// 从文件中读取
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">文件路径</param>
        /// <returns>实体内容</returns>
        internal static T LoadFromFile<T>(String filePath) where T : class
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            T obj = null;

            if (!File.Exists(filePath))
            {
                return obj;
            }

            try
            {
                fs = new FileStream(filePath, FileMode.Open);
                bf = new BinaryFormatter();
                obj = bf.Deserialize(fs) as T;
            }
            catch { }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return obj;
        }

        /// <summary>
        /// 存储到文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="obj">实体内容</param>
        internal static void SaveToFile(String filePath, Object obj)
        {
            FileStream fs = null;
            BinaryFormatter bf = null;

            try
            {
                fs = new FileStream(filePath, FileMode.Create);
                bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
            catch { }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}