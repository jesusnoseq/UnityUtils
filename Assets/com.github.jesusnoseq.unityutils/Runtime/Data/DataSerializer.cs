using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

namespace com.jesusnoseq.util
{
    public class DataSerializer
    {
        //Save Data
        public static void SaveData<T>(T dataToSave, string dataFileName)
        {
            byte[] arrayByte = SerializeData(dataToSave);

            string result = Convert.ToBase64String(arrayByte);

            PlayerPrefs.SetString(dataFileName, result);
        }

        public static T LoadData<T>(string dataFileName)
        {
            string serializeData = PlayerPrefs.GetString(dataFileName);

            byte[] arrayByte = Convert.FromBase64String(serializeData);

            return DeserializeData<T>(arrayByte);
        }

        public static void DeleteData(string dataFileName)
        {
            PlayerPrefs.DeleteKey(dataFileName);
        }

        public static byte[] SerializeData<T>(T data)
        {
            if (data == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        public static T DeserializeData<T>(byte[] arrayByte)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();

            ms.Write(arrayByte, 0, arrayByte.Length);
            ms.Seek(0, SeekOrigin.Begin);
            T obj = (T)bf.Deserialize(ms);

            return obj;
        }
    }
}
