using System.Collections.Generic;

namespace ContactsApp.Model
{
    /// <summary>
    ///  Класс Project, хранит список контактов.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        public List<Person> List { get; set; } = new List<Person>();
    }
}