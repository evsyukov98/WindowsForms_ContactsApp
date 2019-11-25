using System;
using ContactsApp.Model;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    internal class ContactTests
    {
        [SetUp]
        public void InitContact()
        {
            _contact = new Contact("Surname", "Name",
                new DateTime(1987, 7, 20), "+7(777)777-77-77",
                "mail@mail.com", "id");
        }

        private Contact _contact;


        [TestCase(" ", "Исключение, если фамилия - пустая строка", TestName =
            "Присвоение пустой строки в качестве фамилии")]
        [TestCase("Surnamesurnamesurnamesurnamesurnamesurnamesurname",
            "Исключение, если фамилия длиннее 40 символов", TestName =
                "Присвоение неправильной фамилии больше 40 символов")]
        [TestCase("surname", "Исключение, если фамилия - с маленькой буквы", TestName =
            "Присвоение фамилии с маленькой буквы")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; },
                message);

        }

        [Test(Description = "Проверка фамилии")]
        public void TestSurnameSet_CorrectValue()
        {
            var actual = "Surname";
            var expected = _contact.Surname;
            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }

        [TestCase(" ", "Исключение, если имя - пустая строка", TestName =
            "Присвоение пустой строки в качестве имени")]
        [TestCase("Namenamenamenamenamenamenamenamenamenmanem",
            "Исключение, если имя длиннее 40 символов", TestName =
                "Присвоение неправильное имя больше 40 символов")]
        [TestCase("name", "Исключение, если имя - с маленькой буквы", TestName =
            "Присвоение имени с маленькой буквы")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = wrongName; },
                message);
        }

        [Test(Description = "Проверка имени")]
        public void TestNameSet_CorrectValue()
        {
            var actual = "Name";
            var expected = _contact.Name;
            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }


        [TestCase("05/05/2025", "Исключение, если дата больше текущей",
            TestName = "Присвоение даты больше текущей")]
        public void TestBirthdaySet_ArgumentException(string wrongString, string message)
        {
            var wrongBirthday = Convert.ToDateTime(wrongString);
            Assert.Throws<ArgumentException>(
                () => { _contact.Birthday = wrongBirthday; },
                message);
        }

        [Test(Description = "Проверка даты")]
        public void TestBirthdaySet_CorrectValue()
        {
            var actual = new DateTime(1987, 7, 20);
            var expected = _contact.Birthday;
            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }

        [TestCase("8(999)499-51-03", "Исключение, если номер не начинается с +7",
            TestName = "Номер начинается не с +7")]
        [TestCase("+7999499-51-03", "Исключение, если цифры оператора без скобок",
            TestName = "Номер без скобок")]
        [TestCase("+7(999)4995103", "Исключение, если номер без дифисов",
            TestName = "Номер без дифиса")]
        public void TestPhoneSet_ArgumentException(string wrongPhone, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Phone = wrongPhone; },
                message);
        }


        [Test(Description = "Проверка номера")]
        public void TestPhoneSet_CorrectValue()
        {
            var actual = "+7(777)777-77-77";
            var expected = _contact.Phone;
            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }

        [TestCase("@mail.com", "Исключение, если почта не имеет именной части",
            TestName = "Почта без имени")]
        [TestCase("listmail.com", "Исключение, если нет символа @",
            TestName = "Почта без символа @")]
        [TestCase("evsyukov@.com", "Исключение, если почта не имеет название сайта",
            TestName = "Почта без названия сайта")]
        [TestCase("evsyukov@mail", "Исключение, если почта не имеет домена",
            TestName = "Почта без домена")]
        public void TestMailSet_ArgumentException(string wrongMail, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Mail = wrongMail; },
                message);
        }


        [Test(Description = "Проверка фамилии")]
        public void TestMailSet_CorrectValue()
        {
            var actual = "mail@mail.com";
            var expected = _contact.Mail;
            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }

        [TestCase("", "Исключение, если VkID пустая строка ",
            TestName = "VkID пустая строка")]
        [TestCase("idevsyu.kov", "Исключение, если VkID не буква или цифра ",
            TestName = "VkID с другими символами")]
        public void TestVkIdSet_ArgumentException(string wrongVkId, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Mail = wrongVkId; },
                message);
        }
        
        [Test(Description = "Проверка фамилии")]
        public void TestVkIdSet_CorrectValue()
        {
            var actual = "id";
            var expected = _contact.VkId;
            Assert.AreEqual(actual, expected,
                "Сравнение сериализатора ProjectManager и встроенного.");
        }
    }
}