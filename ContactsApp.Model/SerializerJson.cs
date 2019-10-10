using System.IO;
using Newtonsoft.Json;

// ReSharper disable All

namespace ContactsApp.Model
{
    /// <summary>
    ///     Класс SerializerJson, сериализует и десериализует в формат .json
    /// </summary>
    public class SerializerJson<_>
    {
        private string _directory;

        public SerializerJson(string directory)
        {
            Directory = directory;
        }

        /// <summary>
        ///     Задает и возвращает директорию пользователя.
        /// </summary>
        public string Directory
        {
            get => _directory;
            set => _directory = value;
        }

        /// <summary>
        ///     Метод, выполняющий сериализацию.
        /// </summary>
        public void Serialize(_ obj, string name)
        {
            using (TextWriter writer = File.CreateText(_directory + name + ".json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, obj);
            }
        }

        /// <summary>
        ///     Метод, выполняющий десериализацию.
        /// </summary>
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