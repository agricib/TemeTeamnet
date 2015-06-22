using Newtonsoft.Json;
using System.IO;

namespace MyHomeWork
{
    public class JsonHelper<T>
    {
        public static string SerializeObject(T objectToSerialize, string filePath)
        {
            var serializedObject = JsonConvert.SerializeObject(objectToSerialize);
            using (StreamWriter stream = new StreamWriter(filePath))
            {
                stream.Write(serializedObject);
                stream.Close();
            }

            return serializedObject;
        }

        public static T DeserializeObject(string fileToDesirializePath, string desirializedNewFilePath)
        {
            var desirializedObject = JsonConvert.DeserializeObject(fileToDesirializePath,typeof (T));
            using (StreamWriter stream = new StreamWriter(desirializedNewFilePath))
            {
                stream.Write(desirializedObject);
                stream.Close();
            }

            return (T)desirializedObject;
        }
    }
}