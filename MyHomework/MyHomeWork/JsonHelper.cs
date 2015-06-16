using Newtonsoft.Json;
using System.IO;

namespace MyHomeWork
{
    public class JsonHelper
    {
        public static string SerializeObject(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public static object DeserializeObject(string objectToDeserialize)
        {
            return JsonConvert.DeserializeObject(objectToDeserialize);
        }
    }
}