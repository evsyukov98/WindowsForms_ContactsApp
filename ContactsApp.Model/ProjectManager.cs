using System.IO;
using Newtonsoft.Json;


// ReSharper disable All

namespace ContactsApp.Model
{
    /// <summary>
    ///     Класс ProjectManager, сериализует и десериализует.
    /// </summary>
    public static class ProjectManager<T>
    {
        /// <summary>
        ///     Метод, выполняющий сериализацию.
        /// </summary>
        public static void SaveToFile(T name, string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path)
            )
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.NullValueHandling = NullValueHandling.Include;
                serializer.Serialize(writer, name);
            }
        }

        /// <summary>
        ///     Метод, выполняющий десериализацию.
        /// </summary>
        public static T LoadFromFile(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                serializer.NullValueHandling = NullValueHandling.Include;
                var data = serializer.Deserialize<T>(reader);
                return data;
            }
        }
    }
}