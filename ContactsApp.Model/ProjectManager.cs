using System.IO;
using Newtonsoft.Json;

// ReSharper disable All

namespace ContactsApp.Model
{
    /// <summary>
    ///     Класс ProjectManager, сериализует и десериализует
    /// </summary>
    public static class ProjectManager<T>
    {
        /// <summary>
        ///     Метод, выполняющий сериализацию.
        /// </summary>
        public static void Serializer(T name)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(
                @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\peopless.json")
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
        public static T Deserializer()
        {
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(
                @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\peopless.json")
            )
            using (JsonReader reader = new JsonTextReader(sr))
            {
                serializer.NullValueHandling = NullValueHandling.Include;
                var data = serializer.Deserialize<T>(reader);
                return data;
            }
        }
    }
}