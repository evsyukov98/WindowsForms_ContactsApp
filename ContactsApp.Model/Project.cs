using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp.Model
{
    /// <summary>
    ///     Класс Project, хранит список контактов.
    /// </summary>
    public class Project
    {
        /// <summary>
        ///     Список контактов.
        /// </summary>
        public List<Contact> List { get; set; }

        /// <summary>
        ///     Сортировка списка контактов
        /// </summary>
        public List<Contact> SortList()
        {
            var sortedList = List.OrderBy(contact => contact.Surname).ToList();
            return sortedList;
        }

        /// <summary>
        ///     Сортировка списка контактов
        /// </summary>
        public List<Contact> SortList(string substring)
        {
            var findSortedList = from contact in List
                where contact.Surname.StartsWith(substring,
                    StringComparison.OrdinalIgnoreCase)
                orderby contact.Surname
                select contact;

            return findSortedList.ToList();
        }

        /// <summary>
        ///     Возращает писок контактов у которых день рождения.
        /// </summary>
        public List<Contact> BirthdayList()
        {
            var birthdayList = from contact in List
                where contact.Birthday.DayOfYear == DateTime.Now.DayOfYear
                orderby contact.Surname
                select contact;

            return birthdayList.ToList();
        }
    }
}