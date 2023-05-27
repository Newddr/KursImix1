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
    public partial class Form3 : Form
    {
        public Form3(int id)
        {
            InitializeComponent();
            this.id= id;
        }
        private int id = 0;
        private string namecar = "";
        private void Form3_Load(object sender, EventArgs e)
        {
            Class1 class1= new Class1();
            List<String[]> ords = class1.GetAllOrders(id);

            foreach (string[] s in ords)
            {
                namecar = s[4];
                Label name = new Label();

                name.Text = s[0];
                name.Width = 200;
                Label number = new Label();
                number.Font = new Font(number.Font, FontStyle.Bold);
                number.Text = s[1];
                //number.Anchor = AnchorStyles.Right;
                Label cost = new Label();
                cost.Text = s[2]+ " рублей";
                Label time = new Label();
                time.Text = s[3]+" минут";
                FlowLayoutPanel element = new FlowLayoutPanel();
                element.Controls.Add(name);
                element.Controls.Add(number);
                element.Controls.Add(cost);
                element.Controls.Add(time);
                
                element.Dock = DockStyle.Top;
                panel1.Controls.Add(element);
            }
            label1.Text = "Отчет поездок" + namecar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
