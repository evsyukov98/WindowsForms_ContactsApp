using System;
using System.Text.RegularExpressions;

namespace ContactsApp.Model
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _number;
        private string _mail;
        private string _vkId;
        private DateTime _date;

        
        public Person(string name, string surname, string number, DateTime date,
            string mail, string vkId)
        {
            Name = name;
            Surname = surname;
            Number = number;
            Date = date;
            Mail = mail;
            VkId = vkId;
        }

        public string Name
        {
            get => _name;
            set
            {
                var pattern = "[A-Z][a-z]*";

                if (Regex.IsMatch(value, pattern))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_name));
                }
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                var pattern = "[A-Z][a-z]*";
                if (Regex.IsMatch(value, pattern))
                {
                    _surname = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_surname));
                }
            }
        }

       

        public string Number
        {
            get => _number;
            set
            {
                var pattern = @"\+7\(\d{3}\)\d{3}-\d{2}-\d{2}";

                if (Regex.IsMatch(value, pattern))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_number));
                }
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException(nameof(_date));
                }
            }
        }
        public string Mail
        {
            get => _mail;
            set
            {
                var pattern =
                    @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

                if (Regex.IsMatch(value, pattern))
                {
                    _mail = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_mail));
                }
            }
        }

        public string VkId
        {
            get => _vkId;
            set
            {
                var pattern = @"\w+";
                if (Regex.IsMatch(value, pattern))
                {
                    _vkId = value;
                }
                else
                {
                    throw new ArgumentException(nameof(_vkId));
                }
            }
        }
    }
}