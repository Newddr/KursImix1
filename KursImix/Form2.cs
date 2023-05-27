using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KursImix
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        private int idCar = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            Class1 class1= new Class1();

            List<String[]> autos = class1.GetAutos();
            foreach (string[] s in autos) {

                Label name = new Label();

                name.Text = s[0];
                Label number = new Label();
                number.Font  = new Font(number.Font, FontStyle.Bold);
                number.Text = s[1];
                number.Anchor = AnchorStyles.Right;

                FlowLayoutPanel element = new FlowLayoutPanel();
                element.Controls.Add(name);
                element.Controls.Add(number);
                element.Height = 55;
                element.Dock = DockStyle.Top;
                int id = Convert.ToInt32(s[2]);
                name.Click += (labelSender, labelEventArgs) =>
                {
                    autoClick(labelSender, labelEventArgs, id);
                };
                number.Click += (labelSender, labelEventArgs) =>
                {
                    autoClick(labelSender, labelEventArgs, id);
                };
                element.Click += (panelSender, panelEventArgs) =>
                {
                    autoClick(panelSender, panelEventArgs, id);
                };
                panel1.Controls.Add(element);
            }
        }

        private void autoClick(object sender, EventArgs e, int id)
        {
            panel2.Visible= true;

            Class1 class1 = new Class1();
            String[] s = new string[13];
            s = class1.GetFullAutoInfo(id);
            label11.Text = s[0];
            idCar = Convert.ToInt32(s[0]);
            label10.Text = s[2];
            label9.Text = s[1];
            label8.Text = s[3];
            label7.Text = s[4];
            label22.Text = s[7];
            label23.Text = s[6];
            label24.Text = s[8];
            label16.Text = s[11];
            label13.Text = s[10];
            label15.Text = s[12];
            label14.Text = s[9];
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(idCar);
            form3.Show();
            this.Hide();

        }
    }
}
