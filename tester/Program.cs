using ContactsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Project actual = new Project { List = new List<Contact>() };

            actual.List.Add(new Contact("Evsyukov", "Ivan", new DateTime(2001, 7, 20),
                "+7(999)499-51-03)", "evsyukov@mial.com", "hello12"));

            actual.List.Add(new Contact("Suberlyak", "Evgeniyu",
                new DateTime(2001, 7, 20),
                "+7(999)499-51-02)", "suberlyak@mial.com", "hell12"));

            Project expected = ProjectManager<Project>.LoadFromFile(@"example.json"); // используем наш десериализатор

            var actualText = JsonConvert.SerializeObject(actual);
            var expectedText = JsonConvert.SerializeObject(expected);


            Console.WriteLine(actualText==expectedText);
        }
    }
}
