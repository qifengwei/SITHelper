using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Serializer;

namespace APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1 { ID = 3, DataList = new List<string> { "123", "234", "345" } };

            Serializer.Serializer.WriteXML(c1, "666.xml");

            Class1 c2 = 
            Serializer.Serializer.ReadXML<Class1>( "666.xml");

            Console.WriteLine(c2.ID);
            
        }
    }
}
