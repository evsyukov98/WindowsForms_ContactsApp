using System.IO;
using Newtonsoft.Json;

// ReSharper disable All

namespace ContactsApp.Model
{
    /// <summary>
    ///     Класс SerializerJson, сериализует и десериализует
    /// </summary>
    public static class Serializer<T>
    {
        /// <summary>
        ///     Метод, выполняющий сериализацию.
        /// </summary>
        public static void Serialize(T name, string directory)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(directory))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.NullValueHandling = NullValueHandling.Include;
                serializer.Serialize(writer, name);
            }
        }

        /// <summary>
        ///     Метод, выполняющий десериализацию.
        /// </summary>
        public static T Deserialize(string directory)
        {
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(directory))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                serializer.NullValueHandling = NullValueHandling.Include;
                var data = serializer.Deserialize<T>(reader);
                return data;
            }
        }
    }
}