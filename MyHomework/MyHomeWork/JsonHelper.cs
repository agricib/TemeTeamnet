using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork
{
    class JsonHelper
    {
        //de terminat
        public static void SerializeObject(object objectToSerialize)
        {
            Stream stream = File.Open("SerializedData.txt", FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }
        public static void DeserializeObject()
        {
            Stream stream = File.Open("SerializedData.txt", FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Deserialize(stream);
            stream.Close();
        }
    }
}
