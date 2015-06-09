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

        //Stiu ca sunt bou dar nu imi dau seama de ce?? nu se deserializeaza( nu vreau asta intr-un fisier ci aici in debug)
        public static void DeserializeObject()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader file =new  StreamReader(@"d:\serializedFile.json"))
            using (JsonTextReader jTR = new JsonTextReader(file))
            {
                Employee empl = (Employee)serializer.Deserialize(jTR);
                StreamWriter str = File.CreateText(@"d:\deserializedFile.txt");
                //nu imi dau seama cum sa-l scriu. am cautat

            }
        }
    }
}
