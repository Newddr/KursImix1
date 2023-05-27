using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KursImix
{
    public partial class Form1 : Form
    {        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 class1 = new Class1();
            switch (class1.GetLogFromBD(textBox1.Text,textBox2.Text))
            //switch (class1.GetLogFromBD("admin","admin"))
            {
                case 0:
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                    break;
                case 1:
                    label3.Visible = true;
                    label3.Text = "Пользователь не найден";
                    break;
                case 2:
                    label3.Visible = true;
                    label3.Text = "Неверный пароль";
                    break;


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
