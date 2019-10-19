using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    //partial вторая часть кода находиться в Form1.Designer.cs
    public partial class MainForm : Form
    {
        private List<Contact> _contacts = new List<Contact>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEditContact addForm = new AddEditContact();
            addForm.ShowDialog();
            //if ()
            //{
                Contact newContact = addForm.Contact;

                //Добавить новые данные
                _contacts.Add(newContact);
                ContactsListBox.Items.Add(newContact.Name);
            //}
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            
            int selectedIndex = ContactsListBox.SelectedIndex;
            Contact selectedContact = _contacts[selectedIndex];

            // создаем экземпляр формы
            AddEditContact editForm = new AddEditContact(true);
            // отправляем редактируемый элемент 
            editForm.Contact = selectedContact;
            editForm.ShowDialog();
            // забираем измененный контакт
            Contact updatedContact = editForm.Contact;

            //Удалить старые данные по выбранному индексу в лист боксе и нашем листе
            ContactsListBox.Items.RemoveAt(selectedIndex);
            _contacts.RemoveAt(selectedIndex);

            //Добавить новые данные
            _contacts.Insert(selectedIndex, updatedContact);
            ContactsListBox.Items.Insert(selectedIndex, updatedContact.Name);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = ContactsListBox.SelectedIndex;
            _contacts.RemoveAt(index);
            ContactsListBox.Items.RemoveAt(index);
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ContactsListBox.SelectedIndex;
            if (ContactsListBox.SelectedIndex != -1)
            {
                Contact selectedContact = _contacts[selectedIndex];
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

        private void TestButton_Click(object sender, EventArgs e)
        {
            Contact newContact = new Contact("Ivan", "Evsyukov", new DateTime(1998, 7, 20), "+7(777)777-77-77",
                "ivan@mail.com", "vkid");

            _contacts.Add(newContact);
            ContactsListBox.Items.Add(newContact.Name);
            Contact newContact2 = new Contact("Leon", "Tamirov", new DateTime(1978, 11, 10), "+7(777)777-77-77",
                "dagestan@mail.com", "vkidd");

            _contacts.Add(newContact2);
            ContactsListBox.Items.Add(newContact2.Name);
            Contact newContact3 = new Contact("Sasuke", "Uchiha", new DateTime(2012, 1, 30), "+7(777)777-77-77",
                "chidori@mail.com", "vkisd");

            _contacts.Add(newContact3);
            ContactsListBox.Items.Add(newContact3.Name);
        }

        
    }
}
