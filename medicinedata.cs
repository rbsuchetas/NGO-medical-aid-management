using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class medicinedata : Form
    {
        public medicinedata(string s1,string s2,string s3,string s4,string s5,string s6)
        {
            InitializeComponent();
            label1.Text += s1;
            label2.Text += s2;
            label3.Text += s3;
            label4.Text += s4;
            label5.Text += s5;
            label6.Text += s6;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
