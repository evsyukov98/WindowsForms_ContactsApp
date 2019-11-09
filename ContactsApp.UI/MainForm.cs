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
            try
            {
                _project = ProjectManager<Project>.LoadFromFile(@"ContactsApp.notes");
            }
            catch
            {
                var fileInfo = new FileInfo(@"ContactsApp.notes");
                if (!fileInfo.Exists)
                {
                    fileInfo.Create().Close();
                }
            }

            if (_project == null)
            {
                _project = new Project {List = new List<Contact>()};
            }

            _project.List = _project.SortList();
            ContactsListBox.DisplayMember = "Surname";
            ContactsListBox.DataSource = _project.List;
        }

        /// <summary>
        ///     Сохранить список контактов, обновляет в форме.
        /// </summary>
        private void ProjectSave()
        {
            ResetListBox();
            ProjectManager<Project>.SaveToFile(_project, @"ContactsApp.notes");
        }

        /// <summary>
        ///     Сортирует, обновляет форму;
        /// </summary>
        private void ResetListBox()
        {
            _project.List = _project.SortList();
            ContactsListBox.DataSource = _project.List;
        }


        /// <summary>
        ///  Проверить день рождения.
        /// </summary>
        private void CheckBirthday()
        {
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
        }

        /// <summary>
        ///     Редактирования контакта.
        /// </summary>
        private void EditContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;

            var selectedContact = _project.List[selectedIndex];

            var editForm = new ContactForm { Contact = selectedContact };

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
        private void DeleteContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }

            var result = MessageBox.Show(
                $@"Are you sure you want to remove: {_project.List[selectedIndex].Surname}",
                @"Warning", MessageBoxButtons.OKCancel);

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
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            ContactsListBox.DataSource = _project.SortList(FindTextBox.Text);
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