using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    //partial вторая часть кода находиться в Form1.Designer.cs
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Хранит список контактов
        /// </summary>
        private Project _project;

        /// <summary>
        ///     Функция инициализации
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ProjectLoad();
        }

        /// <summary>
        ///     Загрузить список контактов, добавить в ListBox.
        /// </summary>
        private void ProjectLoad()
        {
            try
            {
                _project = ProjectManager<Project>.Deserializer(@"ContactsApp.notes");
            }
            catch
            {
                var fileInf = new FileInfo(@"ContactsApp.notes");
                if (!fileInf.Exists)
                {
                    fileInf.Create().Close();
                }
            }

            if (_project == null)
            {
                _project = new Project {List = new List<Contact>()};
            }

            ContactsListBox.DisplayMember = "Surname";
            ContactsListBox.DataSource = _project.List;
        }

        /// <summary>
        ///     Сохранить список контактов, обновляет в форме.
        /// </summary>
        private void ProjectSave()
        {
            ResetListBox();
            ProjectManager<Project>.Serializer(_project, @"ContactsApp.notes");
        }

        /// <summary>
        ///     Сортирует, обновляет форму;
        /// </summary>
        private void ResetListBox()
        {
            _project.List = _project.List.OrderBy(contact => contact.Surname).ToList();

            ContactsListBox.DataSource = _project.List;
            ContactsListBox.DisplayMember = "Surname";
        }

        /// <summary>
        ///     Кнопка добавления контакта
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditContact();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                //Добавить новые данные в список
                _project.List.Add(addForm.Contact);

                //сохранить все в "ContactsApp.notes"
                ProjectSave();
            }
        }

        /// <summary>
        ///     Кнопка редактирования контакта
        /// </summary>
        private void EditButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;

            // выбранный контакт 
            var selectedContact = _project.List[selectedIndex];

            // создаем экземпляр формы, сразу передаем выбранный контакт 
            var editForm = new AddEditContact {Contact = selectedContact};

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _project.List.RemoveAt(selectedIndex);
                _project.List.Insert(selectedIndex, editForm.Contact);

                ProjectSave();
            }
        }

        /// <summary>
        ///     Конпка удаления контакта
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                _project.List.RemoveAt(selectedIndex);
                ProjectSave();
            }
        }

        /// <summary>
        ///     ListBox контактов: выбранный элемент выводится на TextBox
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex != -1)
            {
                var selectedContact = _project.List[ContactsListBox.SelectedIndex];
                SurnameTextBox.Text = selectedContact.Surname;
                NameTextBox.Text = selectedContact.Name;
                BirthdayDateTimePicker.Value = selectedContact.Birthday;
                PhoneTextBox.Text = selectedContact.Phone;
                MailTextBox.Text = selectedContact.Mail;
                VkIdTextBox.Text = selectedContact.VkId;
            }
            else
            {
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                PhoneTextBox.Text = "";
                MailTextBox.Text = "";
                VkIdTextBox.Text = "";
            }
        }

        /// <summary>
        ///     Тестовая кнопка: создает 3 шаблонных контакта
        /// </summary>
        private void TestButton_Click(object sender, EventArgs e)
        {
            var newContact = new Contact("Evsyukov", "Ivan", new DateTime(1998, 7, 20),
                "+7(777)777-77-77",
                "ivan@mail.com", "vkid");

            _project.List.Add(newContact);

            var newContact2 = new Contact("Tamirov", "Leon", new DateTime(1978, 11, 10),
                "+7(777)777-77-77",
                "dagestan@mail.com", "vkidd");

            _project.List.Add(newContact2);

            var newContact3 = new Contact("Uchiha", "Sasuke", new DateTime(2012, 1, 30),
                "+7(777)777-77-77",
                "chidori@mail.com", "vkisd");

            _project.List.Add(newContact3);

            ResetListBox();
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            var projectList = _project.List;
            var findList = projectList.Where(contact => contact.Surname.StartsWith(FindTextBox.Text)).ToList();
            ContactsListBox.DataSource = findList;
        }
    }
}