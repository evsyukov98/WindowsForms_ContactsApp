using System;
using System.IO;
using Newtonsoft.Json;

namespace ContactsApp.Model
{
    public class Json
    {
        public static void Serialize(Person person)
        {
            using (TextWriter writer = File.CreateText(@"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\JsonSaves\"+person.Name+".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, person);
            }
        }

        public static Person UnSerialize(String person)
        {
            using (TextReader reader = File.OpenText(@"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\JsonSaves\" + person + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Person data = (Person) serializer.Deserialize(reader, typeof(Person));
                return data;
            }
        }
    }
}