using System;
using System.Collections.Generic;
using System.IO;
using ContactsApp.Model;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    internal class ProjectManagerTest
    {
        [Test(Description = "Проверка десериализации")]
        public void TestLoadFromFile_CorrectValue()
        {
            var actual = new Project {List = new List<Contact>()};

            actual.List.Add(new Contact("Evsyukov", "Ivan", new DateTime(2001, 7, 20),
                "+7(999)499-51-03)", "evsyukov@mial.com", "hello12"));

            actual.List.Add(new Contact("Suberlyak", "Evgeniyu",
                new DateTime(2001, 7, 20),
                "+7(999)499-51-02)", "suberlyak@mial.com", "hell12"));

            var expected =
                ProjectManager<Project>
                    .LoadFromFile(@"example.json"); // используем наш десериализатор

            var actualText =
                JsonConvert.SerializeObject(actual); // преобразуем все в текст

            var expectedText =
                JsonConvert.SerializeObject(expected); // преобразуем все в текст

            Assert.AreEqual(actualText, expectedText,
                "Сравнение результата десериализованного обьекта и ожидаемого");
        }

        [Test(Description = "Проверка сериализации")]
        public void TestSaveToFile_CorrectValue()
        {
            var example = new Project {List = new List<Contact>()};

            example.List.Add(new Contact("Evsyukov", "Ivan", new DateTime(2001, 7, 20),
                "+7(999)499-51-03)", "evsyukov@mial.com", "hello12"));

            example.List.Add(new Contact("Suberlyak", "Evgeniyu",
                new DateTime(2001, 7, 20),
                "+7(999)499-51-02)", "suberlyak@mial.com", "hell12"));


            ProjectManager<Project>.SaveToFile(example,
                @"example.json");                               // используем наш сериализатор

            var expected = File.ReadAllText(@"example.json");   // записываем все в строку
            var actual =
                JsonConvert
                    .SerializeObject(example);                  // используем встроенный сериализатор 

            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }
    }
}