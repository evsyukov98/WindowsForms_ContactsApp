using System;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    //partial вторая часть кода находиться в Form1.Designer.cs
    public partial class MainForm : Form
    {
        //класс со списком контактов
        private Project _project;

        public MainForm()
        {
            InitializeComponent();
            ProjectLoad();
        }

        // загружает список контактов 
        private void ProjectLoad()
        {
            _project = ProjectManager<Project>.Deserializer(
                @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\ContactsApp.notes");

            foreach (var project in _project.List)
            {
                ContactsListBox.Items.Add(project.Name);
            }
        }

        private void ProjectSave()
        {
            ProjectManager<Project>.Serializer(_project,
                @"Z:\Ivan\Учеба\4 курс\4-1 НТвП\Лабараторная №2\ContactsApp\ContactsApp.notes");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditContact();
            addForm.ShowDialog();

            var newContact = addForm.Contact;

            //Добавить новые данные в список
            _project.List.Add(newContact);
            //Добавить новые данные в UI
            ContactsListBox.Items.Add(newContact.Name);
            //сохранить все в "ContactsApp.notes"
            ProjectSave();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            var selectedContact = _project.List[selectedIndex];

            // создаем экземпляр формы
            var editForm =
                new AddEditContact {Contact = selectedContact};

            // отправляем редактируемый элемент 
            editForm.ShowDialog();

            // забираем измененный контакт
            var updatedContact = editForm.Contact;

            //Удалить старые данные по выбранному индексу в лист боксе и нашем листе
            ContactsListBox.Items.RemoveAt(selectedIndex);
            _project.List.RemoveAt(selectedIndex);

            //Добавить новые данные в список
            _project.List.Insert(selectedIndex, updatedContact);
            ContactsListBox.Items.Insert(selectedIndex, updatedContact.Name);
            ProjectSave();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var index = ContactsListBox.SelectedIndex;
            _project.List.RemoveAt(index);
            ContactsListBox.Items.RemoveAt(index);
            ProjectSave();
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
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
            else
            {
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                PhoneTextBox.Text = "";
                MailTextBox.Text = "";
                VkIdTextBox.Text = "";
            }
        }

        //временная кнопка для тестов создает 3 обьекта
        private void TestButton_Click(object sender, EventArgs e)
        {
            var newContact = new Contact("Ivan", "Evsyukov", new DateTime(1998, 7, 20),
                "+7(777)777-77-77",
                "ivan@mail.com", "vkid");

            _project.List.Add(newContact);
            ContactsListBox.Items.Add(newContact.Name);
            var newContact2 = new Contact("Leon", "Tamirov", new DateTime(1978, 11, 10),
                "+7(777)777-77-77",
                "dagestan@mail.com", "vkidd");

            _project.List.Add(newContact2);
            ContactsListBox.Items.Add(newContact2.Name);
            var newContact3 = new Contact("Sasuke", "Uchiha", new DateTime(2012, 1, 30),
                "+7(777)777-77-77",
                "chidori@mail.com", "vkisd");

            _project.List.Add(newContact3);
            ContactsListBox.Items.Add(newContact3.Name);
        }
    }
}