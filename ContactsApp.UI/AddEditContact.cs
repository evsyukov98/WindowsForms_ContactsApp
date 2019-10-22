using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    public partial class AddEditContact : Form
    {
        private bool _check = false;
        private Contact _contact;
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

        public AddEditContact()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (_check)
            {
                Contact newContact = new Contact(SurnameTextBox.Text, NameTextBox.Text,
                    BirthdayTimePicker.Value, PhoneTextBox.Text, MailTextBox.Text,
                    VkIdTextBox.Text);

                Contact = newContact;
            }

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            var pattern = "^[A-Z][a-z]*$";
            string text = SurnameTextBox.Text;
            if (!Regex.IsMatch(text, pattern))
            {
                SurnameTextBox.BackColor = Color.Red;
                _check = false;
            }
            else
            {
                SurnameTextBox.BackColor = Color.White;
                _check = true;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            var pattern = "^[A-Z][a-z]*$";
            string text = SurnameTextBox.Text;
            if (!Regex.IsMatch(text, pattern))
            {
                SurnameTextBox.BackColor = Color.Red;
                _check = false;
            }
            else
            {
                SurnameTextBox.BackColor = Color.White;
                _check = true;
            }
        }

        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _check = true;
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            var pattern =
                @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            string text = MailTextBox.Text;
            if (!Regex.IsMatch(text, pattern))
            {
                MailTextBox.BackColor = Color.Red;
                _check = false;
            }
            else
            {
                MailTextBox.BackColor = Color.White;
                _check = true;
            }
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            _check = true;
        }

        private void PhoneTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!PhoneTextBox.MaskFull)
            {
                PhoneTextBox.BackColor = Color.Red;
                _check = false;
            }
            else
            {
                PhoneTextBox.BackColor = Color.White;
                _check = true;
            }
        }
    }
}
