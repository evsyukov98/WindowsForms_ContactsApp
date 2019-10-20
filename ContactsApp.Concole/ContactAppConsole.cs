using System;
using System.Collections.Generic;
using ContactsApp.Model;

namespace ContactsApp.Consol
{
    internal class ContactAppConsole
    {
        private static void Main()
        {
            var project = new Project {List = new List<Contact>()};


            var stop = true;
            while (stop)
            {
                Console.WriteLine(
                    " 1 - Для добавления контакта \n " +
                    "2 - Вывести список контактов \n " +
                    "3 - Удаления контакта \n " +
                    "4 - Вывести информацию о контакте\n " +
                    "5 - Сериализовать  список контактов\n " +
                    "6 - Десеариализовать список контактов\n " +
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
                        project.List
                            .Add(new Contact(surname, name, new DateTime(1998, 7, 20),
                                number,
                                mail,
                                vkId));

                        break;

                    case 2:
                        var count = 0;
                        foreach (var person in project.List
                        )
                        {
                            Console.WriteLine("[" + count + "] " + person.Name);
                            count++;
                        }

                        break;

                    case 3:
                        Console.WriteLine("Введите имя контакта");
                        var temp = Console.ReadLine();
                        foreach (var person in project.List
                        )
                        {
                            if (temp == person.Name)
                            {
                                project.List
                                    .Remove(person);

                                Console.WriteLine("Контакт удален");
                                break;
                            }

                            Console.WriteLine("Введеный контакт не найден");
                        }

                        break;

                    case 4:
                        Console.WriteLine("Введите имя контакта");
                        temp = Console.ReadLine();
                        foreach (var person in project.List
                        )
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
                        Console.WriteLine("Сохраняю все контакты");
                        ProjectManager<Project>.Serializer(project,
                            @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\ContactsApp.notes");

                        break;

                    case 6:
                        Console.WriteLine("Загружаю все контакты");
                        project = ProjectManager<Project>.Deserializer(
                            @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\ContactsApp.notes");

                        break;

                    case 7:
                        project.List
                            .Add(new Contact("Ivan", "Evsyukov",
                                new DateTime(1998, 7, 20), "+7(777)777-77-77",
                                "ivan@mail.com", "vkid"));

                        project.List
                            .Add(new Contact("Andrey", "Ashimov",
                                new DateTime(2010, 7, 20), "+7(999)499-77-77",
                                "ivan@mail.com", "vkid"));

                        project.List
                            .Add(new Contact("Vova", "Laptev",
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