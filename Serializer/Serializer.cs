using System;

namespace Serializer
{
    public static class Serializer
    {
        public static void WriteXML(object obj, string path)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(obj.GetType());
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, obj);
            file.Close();
        }

        public static T ReadXML<T>(string path)
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StreamReader file = new System.IO.StreamReader(
                path);
            
            T obj =  (T)reader.Deserialize(file);
            file.Close();
            return obj;

        }
    }
}
