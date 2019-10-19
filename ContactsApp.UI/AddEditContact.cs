using System;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.UI
{
    public partial class AddEditContact : Form
    {
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
            Contact newContact = new Contact(SurnameTextBox.Text, NameTextBox.Text, 
                BirthdayTimePicker.Value, PhoneTextBox.Text, MailTextBox.Text, VkIdTextBox.Text);
            Contact = newContact;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void BirthdayTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
