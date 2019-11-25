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
        [Test(Description = "Проверка сериализации")]
        public void TestSaveToFile_CorrectValue()
        {
            var example = new Project { List = new List<Contact>() };

            example.List.Add(new Contact("Evsyukov", 
                "Ivan", 
                new DateTime(2001, 7, 20),
                "+7(999)499-51-03)", 
                "evsyukov@mial.com", 
                "hello12"));

            example.List.Add(new Contact("Suberlyak", 
                "Evgeniyu",
                new DateTime(2001, 7, 20),
                "+7(999)499-51-02)", 
                "suberlyak@mial.com", 
                "hell12"));


            ProjectManager<Project>.SaveToFile(example, @"expected.json");

            var expected = File.ReadAllText(@"expected.json");
            var actual = File.ReadAllText(@"example.json");

            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }

        [Test(Description = "Проверка десериализации")]
        public void TestLoadFromFile_CorrectValue()
        {
            var actual = new Project {List = new List<Contact>()};

            actual.List.Add(new Contact("Evsyukov", 
                "Ivan", 
                new DateTime(2001, 7, 20),
                "+7(999)499-51-03)",
                "evsyukov@mial.com",
                "hello12"));

            actual.List.Add(new Contact("Suberlyak", 
                "Evgeniyu",
                new DateTime(2001, 7, 20),
                "+7(999)499-51-02)", 
                "suberlyak@mial.com", 
                "hell12"));

            var expected = ProjectManager<Project>.LoadFromFile(@"example.json");

            for (int i = 0; i < actual.List.Count; i++)
            {
                Assert.AreEqual(actual.List[i].Surname,expected.List[i].Surname ,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.List[i].Name, expected.List[i].Name,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.List[i].Birthday, expected.List[i].Birthday,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.List[i].Phone, expected.List[i].Phone,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.List[i].Mail, expected.List[i].Mail,
               "Сравнение результата десериализованного обьекта и ожидаемого");

                Assert.AreEqual(actual.List[i].VkId, expected.List[i].VkId,
               "Сравнение результата десериализованного обьекта и ожидаемого");
            }
        }
    }
}