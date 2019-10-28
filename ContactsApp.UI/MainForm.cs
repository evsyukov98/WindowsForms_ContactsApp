using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ContactsApp.Model;

// ReSharper disable All

namespace ContactsApp.UI
{
    //partial вторая часть кода находиться в Form1.Designer.cs
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Хранит список контактов.
        /// </summary>
        private Project _project;

        /// <summary>
        ///     Функция инициализации.
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
        ///     Кнопка добавления контакта.
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
        ///     Кнопка редактирования контакта.
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
        ///     Конпка удаления контакта.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to remove:{_project.List[selectedIndex].Surname}",
                "Remove", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                _project.List.RemoveAt(selectedIndex);
                ProjectSave();
            }
        }

        /// <summary>
        ///     ListBox контактов: выбранный элемент выводится на TextBox.
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
        ///     Поиск по фамилии.
        /// </summary>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            var projectList = _project.List;
            var findList = projectList
                .Where(contact => contact.Surname.StartsWith(FindTextBox.Text)).ToList();

            ContactsListBox.DataSource = findList;
        }

        /// <summary>
        ///     Меню выход
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            ProjectSave();
        }

        /// <summary>
        ///     Меню добавление контакта
        /// </summary>
        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddButton_Click(sender, e);
        }

        /// <summary>
        ///     Меню редактирование контакта
        /// </summary>
        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditButton_Click(sender, e);
        }

        /// <summary>
        ///     Меню удалить контакт
        /// </summary>
        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteButton_Click(sender, e);
        }

        /// <summary>
        ///     Меню открыть форму About 
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new About();
            aboutForm.ShowDialog();
        }
    }
}