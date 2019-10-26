using System;
using ContactsApp.Model;

namespace ContactApp.UnitTest
{
    using ContactsApp.Model;
    internal class ContactTest
    {
        public void Test_Contact_Suite()
        {
            Test_Surname_Set_CorrectValue();
            Test_Surname_Set_UncorrectValue();
            Test_Surname_Get_CorrectValue();
        }

        private void Test_Surname_Get_CorrectValue()
        {
            //Setup - Подготовка объекта к тестированию
            Contact contact = new Contact("Смирнов", "Laptev",
                new DateTime(1967, 7, 20), "+7(777)777-77-77",
                "ivan@mail.com", "vkid");

            //Выполнение тестируемого метода и сравнение с ожидаемым значением
            if (contact.Surname == "Смирнов")
            {
                // Test Description + Test Result
                Console.WriteLine("Тест Surname возврата корректной фамилии: пройден");
            }
            else
            {
                Console.WriteLine("Тест Surname возврата корректной фамилии: провален");
            }

        }

        private void Test_Surname_Set_UncorrectValue()
        {
            
        }

        private void Test_Surname_Set_CorrectValue()
        {
            
        }
    }
}