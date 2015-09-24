using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hospital_mgmt_CEFC
{
    public partial class option_LCH : Form
    {
        public option_LCH()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Doctor_LCH doc = new Doctor_LCH();
            doc.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            employee_LCH empl = new employee_LCH();
            empl.Show();
            this.Close();


     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void option_LCH_Load(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();

        }
    }
}
