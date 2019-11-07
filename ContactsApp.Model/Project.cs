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

        public List<Contact> SortedList()
        {
            var sortedList = List.OrderBy(contact => contact.Surname).ToList();
            return sortedList;
        }

        public List<Contact> SortedList(string substring)
        {
            var findSortedList = from contact in List
                                 where contact.Surname.StartsWith(substring,
                                     StringComparison.OrdinalIgnoreCase)
                                 orderby contact.Surname
                                 select contact;

            return findSortedList.ToList();
        }

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