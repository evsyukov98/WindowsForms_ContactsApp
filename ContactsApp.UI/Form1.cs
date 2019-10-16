using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp.UI
{
    //partial вторая часть кода находиться в Form1.Designer.cs
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Главное окно программы";
            this.Size = new Size(400, 250);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
