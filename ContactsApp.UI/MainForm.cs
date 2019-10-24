using System;
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
            _project = ProjectManager<Project>.Deserializer(@"ContactsApp.notes");

            foreach (var contact in _project.List)
            {
                ContactsListBox.Items.Add(contact.Surname);
            }
        }

        /// <summary>
        ///     Сохранить список контактов
        /// </summary>
        private void ProjectSave()
        {
            //TODO: сортировка
            //_project.List = _project.List.OrderBy(u => u.Surname).ToList();
            ProjectManager<Project>.Serializer(_project, @"ContactsApp.notes");
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

                //Добавить новые данные в UI
                ContactsListBox.Items.Add(addForm.Contact.Surname);

                //сохранить все в "ContactsApp.notes"
                ProjectSave();
            }
        }

        /// <summary>
        ///     Кнопка редактирования контакта
        /// </summary>
        private void EditButton_Click(object sender, EventArgs e)
        {
            // индекс выбранного в ListBox
            var selectedIndex = ContactsListBox.SelectedIndex;
            // выбранный контакт = список.контактов[индекс выбранного в ListBox]
            var selectedContact = _project.List[selectedIndex];

            // создаем экземпляр формы, сразу передаем выбранный контакт 
            var editForm = new AddEditContact {Contact = selectedContact};


            if (editForm.ShowDialog() == DialogResult.OK)
            {
                //Удалить старые данные по выбранному индексу
                ContactsListBox.Items.RemoveAt(selectedIndex);
                _project.List.RemoveAt(selectedIndex);

                //Добавить новые данные в список
                ContactsListBox.Items.Insert(selectedIndex, editForm.Contact.Surname);
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
                ContactsListBox.Items.RemoveAt(selectedIndex);
                ProjectSave();
            }
        }

        /// <summary>
        ///     ListBox контактов: выбранный элемент выводится на TextBox
        /// </summary>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;

            // если выбрали элемент то вывести их на текст боксах
            if (ContactsListBox.SelectedIndex != -1)
            {
                var selectedContact = _project.List[selectedIndex];
                SurnameTextBox.Text = selectedContact.Surname;
                NameTextBox.Text = selectedContact.Name;
                BirthdayDateTimePicker.Value = selectedContact.Birthday;
                PhoneTextBox.Text = selectedContact.Phone;
                MailTextBox.Text = selectedContact.Mail;
                VkIdTextBox.Text = selectedContact.VkId;
            }
            //если выбранный элемент -1 значит элемента уже нет в списке,
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
            ContactsListBox.Items.Add(newContact.Surname);
            var newContact2 = new Contact("Tamirov", "Leon", new DateTime(1978, 11, 10),
                "+7(777)777-77-77",
                "dagestan@mail.com", "vkidd");

            _project.List.Add(newContact2);
            ContactsListBox.Items.Add(newContact2.Surname);
            var newContact3 = new Contact("Uchiha", "Sasuke", new DateTime(2012, 1, 30),
                "+7(777)777-77-77",
                "chidori@mail.com", "vkisd");

            _project.List.Add(newContact3);
            ContactsListBox.Items.Add(newContact3.Surname);
        }
    }
}