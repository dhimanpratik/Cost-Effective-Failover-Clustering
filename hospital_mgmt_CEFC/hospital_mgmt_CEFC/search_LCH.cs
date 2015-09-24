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
    public partial class search_LCH : Form
    {
        public static CEFCServiceReference.Service1Client ser = new CEFCServiceReference.Service1Client();
       public static CEFCServiceReference.Class_Patient pser = new CEFCServiceReference.Class_Patient();
        
        public search_LCH()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show ();
                this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = pno.Text;
            bool hasDigit = false;
            foreach (char letter in text)
            {
                if (char.IsDigit(letter))
                {
                    hasDigit = true;
                    break;
                }
            }
            // Call SetError or Clear on the ErrorProvider.
            if (!hasDigit)
            {

                errorProvider1.SetError(pno, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pser = ser.Find(Convert.ToInt32(pno.Text));
            if (pser.patientName == "error")
            {
                MessageBox.Show("Couldn't connect to any database at the moment","LIFECARE");
            }
            else
            {
                report_LCH rp = new report_LCH();
                rp.Show();
            }
        }
    }
}
