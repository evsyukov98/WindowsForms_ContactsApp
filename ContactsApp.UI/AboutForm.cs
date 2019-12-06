using System.Diagnostics;
using System.Windows.Forms;

namespace ContactsApp.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void MailHyperlink_LinkClicked(object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://mail.ru");
        }

        private void GithubHyperlink_LinkClicked(object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://github.com");
        }
    }
}