﻿using System;
using System.Collections.Generic;
using ContactsApp.Model;

namespace ContactsApp.Consol
{
    internal class ContactAppConsole
    {
        private static void Main()
        {
            var persons = new List<Contact>();


            var stop = true;
            while (stop)
            {
                Console.WriteLine(
                    " 1 - Для добавления контакта \n " +
                    "2 - Вывести список контактов \n " +
                    "3 - Удаления контакта \n " +
                    "4 - Вывести информацию о контакте\n " +
                    "5 - Сериализовать контакт\n " +
                    "6 - Десеариализовать контакт\n " +
                    "7 - Создать 3 обьекта для теста\n " +
                    "8 - Остановить работу консоли\n");

                var selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.WriteLine("\nВведите фамилию:");
                        var surname = Console.ReadLine();
                        Console.WriteLine("\nВведите имя:");
                        var name = Console.ReadLine();
                        Console.WriteLine("\nВведите номер:");
                        var number = Console.ReadLine();
                        Console.WriteLine("\nВведите почту:");
                        var mail = Console.ReadLine();
                        Console.WriteLine("\nВведите vkid:");
                        var vkId = Console.ReadLine();
                        persons.Add(new Contact(surname, name, new DateTime(1998, 7, 20),
                            number,
                            mail,
                            vkId));

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
                                                  person.Phone + "\n Дата:" +
                                                  person.Birthday.ToString("d") +
                                                  "\n Почта:" + person.Mail + "\n Vkid:" +
                                                  person.VkId);
                            }
                        }

                        break;


                    case 5:
                        Console.WriteLine("Введите имя контакта");
                        temp = Console.ReadLine();
                        foreach (var person in persons)
                        {
                            if (person.Name == temp)
                            {
                                Serializer<Contact>.Serialize(person,
                                    @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\peopless.json");
                            }
                        }

                        break;

                    case 6:
                        persons.Add(Serializer<Contact>.Deserialize(
                            @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\people.json"));

                        break;

                    case 7:
                        persons.Add(new Contact("Ivan", "Evsyukov",
                            new DateTime(1998, 7, 20), "+7(777)777-77-77",
                            "ivan@mail.com", "vkid"));

                        persons.Add(new Contact("Andrey", "Ashimov",
                            new DateTime(2010, 7, 20), "+7(999)499-77-77",
                            "ivan@mail.com", "vkid"));

                        persons.Add(new Contact("Vova", "Laptev",
                            new DateTime(1967, 7, 20), "+7(777)777-77-77",
                            "ivan@mail.com", "vkid"));

                        break;

                    case 8:
                        stop = false;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }
    }
}