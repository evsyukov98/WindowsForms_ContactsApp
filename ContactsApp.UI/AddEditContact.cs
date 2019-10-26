﻿using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    public partial class AddEditContact : Form
    {
        /// <summary>
        /// Конструктор AddEditContact
        /// </summary>
        public AddEditContact()
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

            Close();
        }
        /// <summary>
        /// Кнопка выхода
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Проверка на валидность полей, блокирует кнопку "OK".
        /// </summary>
        private void ValidateAllData()
        {
            OkButton.Enabled = false;

            var patternNames = "^[A-Z][a-z]{0,30}$";
            if (!Regex.IsMatch(SurnameTextBox.Text, patternNames))
            {
                SurnameTextBox.BackColor = Color.Red;
                return;
            }

            SurnameTextBox.BackColor = Color.White;


            if (!Regex.IsMatch(NameTextBox.Text, patternNames))
            {
                NameTextBox.BackColor = Color.Red;
                return;
            }

            NameTextBox.BackColor = Color.White;


            var patternMail =
                @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            if (!Regex.IsMatch(MailTextBox.Text, patternMail))
            {
                MailTextBox.BackColor = Color.Red;
                return;
            }

            MailTextBox.BackColor = Color.White;

            var pattern = @"[0-9a-zA-Z]+";
            if (!Regex.IsMatch(VkIdTextBox.Text, pattern))
            {
                return;
            }


            if (!PhoneTextBox.MaskFull)
            {
                PhoneTextBox.BackColor = Color.Red;
                return;
            }

            PhoneTextBox.BackColor = Color.White;

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