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
                if (Regex.IsMatch(value, pattern))
                {
                    Console.WriteLine("Имя подтверждено");
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
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
                    Console.WriteLine("Фамилия Подтверждена");
                    _surname = value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
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
                    Console.WriteLine("Дата подтверждена");
                    _date = value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }

        public string Number
        {
            get => _number;
            set
            {
                var pattern = @"\+7\(\d{3}\)-\d{3}-\d{2}-\d{2}";
                if (Regex.IsMatch(value, pattern))
                {
                    Console.WriteLine("Номер подтвержден");
                    _number = value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }

        public string Mail
        {
            get => _mail;
            set
            {
                var pattern = @"\w+@\w+\.w+";
                if (Regex.IsMatch(value, pattern))
                {
                    Console.WriteLine("Номер подтверждена");
                    _mail = value;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
        }
    }
}