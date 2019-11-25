using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
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
            CheckBirthday();
        }

        /// <summary>
        ///     Загрузить список контактов, добавить в ListBox.
        /// </summary>
        private void ProjectLoad()
        {
            var path =
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                + @"\ContactsApp";

            try
            {
                _project =
                    ProjectManager<Project>.LoadFromFile(path + @"\ContactsApp.notes");
            }
            catch
            {
                var dirInfo = new DirectoryInfo(path);
                var fileInfo = new FileInfo(path + @"\ContactsApp.notes");

                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    fileInfo.Create().Close();
                }
                else if (!fileInfo.Exists)
                {
                    fileInfo.Create().Close();
                }
            }

            if (_project == null)
            {
                _project = new Project {List = new List<Contact>()};
            }

            ResetListBox();
        }

        /// <summary>
        ///     Сохранить список контактов, обновляет в форме.
        /// </summary>
        private void ProjectSave()
        {
            var path =
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                + @"\ContactsApp\ContactsApp.notes";

            ProjectManager<Project>.SaveToFile(_project, path);
            ResetListBox();
        }

        /// <summary>
        ///     Сортирует, обновляет форму;
        /// </summary>
        private void ResetListBox()
        {
            _project.List = _project.SortList();
            ContactsListBox.DataSource = _project.List;
            ContactsListBox.DisplayMember = "Surname";
        }


        /// <summary>
        ///     Проверить день рождения.
        /// </summary>
        private void CheckBirthday()
        {
            if (_project.BirthdayList().Count == 0)
            {
                BirthdayListBox.Hide();
                BirthdayList.Hide();
                return;
            }

            BirthdayListBox.DisplayMember = "Surname";
            BirthdayListBox.DataSource = _project.BirthdayList();
        }

        /// <summary>
        ///     Добавление контакта.
        /// </summary>
        private void AddContact()
        {
            var addForm = new ContactForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _project.List.Add(addForm.Contact);

                ProjectSave();
            }

            FindTextBoxCheck();
        }

        /// <summary>
        ///     Редактирования контакта.
        /// </summary>
        private void EditContact()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }

            var selectedContact = (Contact) ContactsListBox.SelectedItem;


            var editForm = new ContactForm {Contact = selectedContact};

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _project.List.Remove(selectedContact);
                _project.List.Add(editForm.Contact);
                ProjectSave();
            }

            FindTextBoxCheck();
        }

        /// <summary>
        ///     Конпка удаления контакта.
        /// </summary>
        private void DeleteContact()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }

            var selectedContact = (Contact) ContactsListBox.SelectedItem;

            var result = MessageBox.Show(
                $@"Are you sure you want to remove: {selectedContact.Surname}",
                @"Warning", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                _project.List.Remove(selectedContact);
                ProjectSave();
            }

            FindTextBoxCheck();
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
        ///     Меню открыть форму About
        /// </summary>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        ///     Поиск по фамилии.
        /// </summary>
        private void FindTextBoxCheck()
        {
            if (!FindTextBox.Contains(null))
            {
                ContactsListBox.DataSource = _project.SortList(FindTextBox.Text);
            }
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            FindTextBoxCheck();
        }

        /// <summary>
        ///     Меню выход
        /// </summary>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            ProjectSave();
        }

        /// <summary>
        ///     Меню добавление контакта
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        ///     Меню редактирование контакта
        /// </summary>
        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        ///     Меню удалить контакт
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        /// <summary>
        ///     Меню добавление контакта
        /// </summary>
        private void AddContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        ///     Меню редактирование контакта
        /// </summary>
        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        ///     Меню удалить контакт
        /// </summary>
        private void RemoveContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }
    }
}