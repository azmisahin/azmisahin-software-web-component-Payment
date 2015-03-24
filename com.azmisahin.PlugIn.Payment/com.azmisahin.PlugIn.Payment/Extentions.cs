using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/// <summary>
/// com.azmisahin.Extensions [ Part ]
/// </summary>
/// namespace 
namespace com.azmisahin.Extensions
{
    /// <summary>
    /// Binary tip işlemleri
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Binary<T>
    {
        /// <summary>
        /// Obje data yı dosyaya yazar
        /// </summary>
        /// <param name="data">obje[ class, obje, string ]</param>
        /// <param name="name">dosya adı</param>
        public void writeDataFile(T data, string name)
        {
            FileStream fileStream = new FileStream(name, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        /// <summary>
        /// obje datayı dosyadan okur
        /// </summary>
        /// <param name="name">dosya adı</param>
        /// <returns>obje tipi</returns>
        public T readDataFile(string name)
        {
            FileStream fileStream = new FileStream(name, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            T data = (T)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return data;
        }
    }
}