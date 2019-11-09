using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Конструктор AddEditContact
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Класс Contact
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Создает экземпляр класса Contact
        /// Изменяет все TextBox 
        /// </summary>
        public Contact Contact
        {
            get => _contact;
            set
            {
                if (value != null)
                {
                    _contact = value;

                    SurnameTextBox.Text = Contact.Surname;
                    NameTextBox.Text = Contact.Name;
                    BirthdayTimePicker.Value = Contact.Birthday;
                    PhoneTextBox.Text = Contact.Phone;
                    MailTextBox.Text = Contact.Mail;
                    VkIdTextBox.Text = Contact.VkId;
                }
            }
        }

        /// <summary>
        /// Вызывает конструктор класса
        /// </summary>
        private void OkButton_Click(object sender, EventArgs e)
        {
            Contact = new Contact(SurnameTextBox.Text, NameTextBox.Text,
                BirthdayTimePicker.Value, PhoneTextBox.Text, MailTextBox.Text,
                VkIdTextBox.Text);

            DialogResult = DialogResult.OK;
            
        }
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            
        }

        /// <summary>
        ///  Проверка на символы
        /// </summary>
        private bool RegexCheck(string pattern, TextBox textBox)
        {
            if (!Regex.IsMatch(textBox.Text, pattern))
            {
                textBox.BackColor = Color.LightPink;
                return false;
            }
            textBox.BackColor = Color.White;
            return true;
        }

        /// <summary>
        /// Проверка на валидность полей, блокирует кнопку "OK".
        /// </summary>
        private void ValidateAllData()
        {
            OkButton.Enabled = false;

            var patternNames = "^[A-Z][a-z]{0,30}$";
            var patternMail =
                @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            var patternVkId = @"\w{1,30}";

            if (!RegexCheck(patternNames, SurnameTextBox))
                return;

            if (!RegexCheck(patternNames, NameTextBox))
                return;

            if (!PhoneTextBox.MaskFull)
            {
                PhoneTextBox.BackColor = Color.LightPink;
                return;
            }

            PhoneTextBox.BackColor = Color.White;

            if (!RegexCheck(patternMail, MailTextBox))
                return;

            if (!RegexCheck(patternVkId, VkIdTextBox))
                return;


            OkButton.Enabled = true;
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAllData();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAllData();
        }

        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ValidateAllData();
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAllData();
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateAllData();
        }

        private void PhoneTextBox_MaskInputRejected(object sender,
            MaskInputRejectedEventArgs e)
        {
            ValidateAllData();
        }
    }
}