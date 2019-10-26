using System;
using ContactsApp.Model;
using NUnit.Framework;

namespace ContactsApp.UnitTest
{
    //для того чтобы отличить класс для тестов  и обычные классы
    [TestFixture]
    internal class ContactTest
    {
        [SetUp]
        public void InitContact()
        {
            _contact = new Contact("Surename", "Name",
                new DateTime(1967, 7, 20), "+7(777)777-77-77",
                "ml@mail.com", "id");
        }

        public void Test_Contact_Suite()
        {
            Test_Surname_Get_CorrectValue();
        }

        private Contact _contact;


        [TestCase(" ", "Исключение, если фамилия - пустая строка", TestName =
            "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Ssssssssssssssssssssssssssssssssss",
            "Исключение, если фамилия длиннее 40 символов",
            Ignore = "Тест игнорируется",
            TestName = "Присвоение неправильной фамилии больше 40 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; },
                message);
        }


        [Test(Description = "Позитивный тест геттера Surname")]
        public void Test_Surname_Get_CorrectValue()
        {
            var expected = "Smirnov";
            var contact = new Contact("Surename", "Name",
                new DateTime(1967, 7, 20), "+7(777)777-77-77",
                "ml@mail.com", "id") {Surname = expected};

            var actual = contact.Surname;

            Assert.AreEqual(expected, actual,
                "Геттер Surname возвращает неправильную фамилию");
        }
    }
}