using System.IO;
using Newtonsoft.Json;

namespace ContactsApp.Model
{
    public class Json
    {
        private static string _directory ;
        public Json (string directory)
        {
            Directory = directory;
        }

        public string Directory
        {
            get => _directory;
            set => _directory = value;
        }

        public void Serialize(Person person)
        {
            using (TextWriter writer = File.CreateText(_directory + person.Name + ".json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, person);
            }
        }

        public Person UnSerialize(string person)
        {
            using (TextReader reader = File.OpenText(
                _directory +
                person + ".json"))
            {
                var serializer = new JsonSerializer();
                var data = (Person) serializer.Deserialize(reader, typeof(Person));
                return data;
            }
        }
    }
}