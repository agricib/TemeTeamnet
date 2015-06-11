using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    public class JsonHelper
    {
        public static void SerializeObject(object objectToSerialize)
        {
            using (StreamWriter file = File.CreateText(@"d:\serializedFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, objectToSerialize);
            }
        }


        public static void DeserializeObject()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader file =new  StreamReader(@"d:\serializedFile.json"))
            using (JsonTextReader jTR = new JsonTextReader(file))
            {
                var empl = serializer.Deserialize<Employee>(jTR);
                using (StreamWriter str = File.CreateText(@"d:\deserializedFile.txt"))
                {
                    str.Write(empl.ToString());
                }
            }
        }
    }
}
