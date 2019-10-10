using System;
using System.Collections.Generic;
using ContactsApp.Model;

namespace ContactsApp.Consol
{
    internal class Program
    {
        private static void Main()
        {
            var persons = new List<Person>();

            var stop = true;
            while (stop)
            {
                Console.WriteLine(
                    " 1 - Для добавления контакта \n 2 - Вывести список контактов \n 3 - Удаления контакта \n 4 - Вывести информацию о контакте\n 5 - Остановить работу консоли");

                var selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("\nВведите имя:");
                        var name = Console.ReadLine();
                        Console.WriteLine("\nВведите фамилию:");
                        var surname = Console.ReadLine();
                        Console.WriteLine("\nВведите номер:");
                        var number = Console.ReadLine();
                        Console.WriteLine("\nВведите дату:");
                        var date = Console.ReadLine();
                        Console.WriteLine("\nВведите почту:");
                        var mail = Console.ReadLine();
                        Console.WriteLine("\nВведите vkid:");
                        var vkid = Console.ReadLine();
                        persons.Add(new Person(name, surname, number, date, mail, vkid));
                        break;

                    case 2:
                        var count = 0;
                        foreach (var person in persons)
                        {
                            Console.WriteLine("[" + count + "] " + person.Name);
                            count++;
                        }

                        break;

                    case 3:
                        Console.WriteLine("Введите имя контакта");
                        var temp = Console.ReadLine();
                        foreach (var person in persons)
                        {
                            if (temp == person.Name)
                            {
                                persons.Remove(person);
                                Console.WriteLine("Контакт удален");
                                break;
                            }

                            Console.WriteLine("Введеный контакт не найден");
                        }

                        break;
                    case 4:
                        Console.WriteLine("Введите имя контакта");
                        temp = Console.ReadLine();
                        foreach (var person in persons)
                        {

                            if (person.Name == temp)
                            {
                                Console.WriteLine("\nИмя: " + person.Name + "\nФамилия:" +
                                                  person.Surname + "\n Номер:" +
                                                  person.Number + "\n Дата:" +
                                                  person.Date +
                                                  "\n Почта:" + person.Mail + "\n Vkid:" +
                                                  person.Vkid);
                            }
                        }

                        break;

                    case 5:
                        stop = false;
                        break;

                    case 6:
                        persons.Add(new Person("Ivan", "Evsyukov", "+7(777)777-77-77",
                            "01.01.1978", "ivan@mail.com", "vkid"));

                        persons.Add(new Person("Andrey", "Ashimov", "+7(999)499-77-77",
                            "01.01.1978", "ivan@mail.com", "vkid"));

                        persons.Add(new Person("Vova", "Laptev", "+7(777)777-77-77",
                            "01.01.1978", "ivan@mail.com", "vkid"));

                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}