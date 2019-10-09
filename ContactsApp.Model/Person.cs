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
                while (true)
                {
                    if (Regex.IsMatch(
                        value ?? throw new ArgumentNullException(nameof(value)), pattern))
                    {
                        _name = value;
                        break;
                    }

                    Console.WriteLine("Некорректный ввод");
                    Console.WriteLine("Повторите ввод в формате: Ivan");
                    value = Console.ReadLine();
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

                while (true)
                {
                    if (Regex.IsMatch(value ?? throw new ArgumentNullException(nameof(value)), pattern))
                    {
                        _date = value;
                        break;
                    }

                    Console.WriteLine("Некорректный ввод даты");
                    Console.WriteLine("Повторите ввод в формате: 01.01.1111");
                    value = Console.ReadLine();
                }
            }
        }

        public string Number
        {
            get => _number;
            set
            {
                var pattern = @"\+7\(\d{3}\)\d{3}-\d{2}-\d{2}";
                while (true)
                {
                    if (Regex.IsMatch(value ?? throw new ArgumentNullException(nameof(value)), pattern))
                    {
                        _number = value;
                        break;
                    }

                    Console.WriteLine("Некорректный ввод номера");
                    Console.WriteLine("Повторите ввод в формате: +7(777)777-77-77");
                    value = Console.ReadLine();
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

                while (true)
                {
                    if (Regex.IsMatch(value ?? throw new ArgumentNullException(nameof(value)), pattern))
                    {
                        _mail = value;
                        break;
                    }

                    Console.WriteLine("Некорректный ввод почты");
                    Console.WriteLine("Повторите ввод в формате: ivanov@mail.com");
                    value = Console.ReadLine();
                }
            }
        }
    }
}