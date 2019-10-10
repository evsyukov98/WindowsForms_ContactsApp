using System.IO;
using Newtonsoft.Json;

namespace ContactsApp.Model
{
    public class SerializerJson<_>
    {
        protected string _directory;

        public SerializerJson(string directory)
        {
            Directory = directory;
        }

        public string Directory
        {
            get => _directory;
            set => _directory = value;
        }

        public void Serialize(_ person, string name)
        {
            using (TextWriter writer = File.CreateText(_directory + name + ".json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, person);
            }
        }

        public _ UnSerialize(string person)
        {
            using (TextReader reader = File.OpenText(
                _directory +
                person + ".json"))
            {
                var serializer = new JsonSerializer();
                var data = (_) serializer.Deserialize(reader, typeof(_));
                return data;
            }
        }
    }
}