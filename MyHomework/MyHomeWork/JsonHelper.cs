using Newtonsoft.Json;
using System.IO;

namespace MyHomeWork
{
    public class JsonHelper<T>
    {
        public static string SerializeObject(T objectToSerialize,string filePath)
        {
            var serializedObject = JsonConvert.SerializeObject(objectToSerialize);
            using (StreamWriter stream = new StreamWriter(filePath))
            {
                stream.Write(serializedObject);
                stream.Close();
            }

            return serializedObject;
        }

        public static T DeserializeObject(string filePath)
        {
            var desiriaizedObject =  (T)JsonConvert.DeserializeObject(filePath);
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                //sa scrie deserializarea in alt fisier. de terminat(desiriaizedObject);
                stream.Close();
            }

            return desiriaizedObject;
        }
    }
}