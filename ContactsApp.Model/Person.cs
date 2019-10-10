using System;
using System.Text.RegularExpressions;

namespace ContactsApp.Model
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _date;
        private string _number;
        private string _mail;
        public string Vkid;
        

        public Person(string name, string surname, string number, string date,
            string mail, string vkid)
        {
            Name = name;
            Surname = surname;
            Number = number;
            Date = date;
            Mail = mail;
            Vkid = vkid;
        }

        public string Name
        {
            get => _name;
            set
            {
                var pattern = "[A-Z][a-z]*";

                if (Regex.IsMatch(value , pattern))
                {
                    _name = value;
                }
                else
                {
                    _name = null;
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
                    _name = null;
                }
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                var pattern = @"[0-3][0-9]\.[0-1][0-9]\.[0-9]{4}";

                
                    if (Regex.IsMatch(value, pattern))
                    {
                        _date = value;
                    }
                    else
                    {
                        _date = null;
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
                    _number = null;
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

                    if (Regex.IsMatch(value , pattern))
                    {
                        _mail = value;
                    }
                    else
                    {
                        _mail = null;
                    }
            }
        }
    }
}