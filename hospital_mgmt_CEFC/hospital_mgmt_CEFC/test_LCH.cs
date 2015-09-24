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
    public partial class test_LCH : Form
    {
        CEFCServiceReference.Class_Test ct = new CEFCServiceReference.Class_Test();
        CEFCServiceReference.Service1Client client = new CEFCServiceReference.Service1Client();
        public test_LCH()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            report_LCH report = new report_LCH();
            report.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ct.patientNo = Convert.ToInt32(pno.Text);
            ct.testdate = Convert.ToDateTime(dateTimePicker1.Text);
            ct.testhead = testhead.Text;
            ct.remarks = remarks.Text;
            ct.amount = amount.Text;
            client.InsertNewTest(ct);
            MessageBox.Show("RECORD ADDED SUCCESSFULLY!!!", "LIFECARE");
        }

        private void test_LCH_Load(object sender, EventArgs e)
        {
            search_LCH sr = new search_LCH();
            pno.Text = Convert.ToString(search_LCH.pser.patientNo);

       }

        private void button2_Click(object sender, EventArgs e)
        {
            pno.Text = "";
            
            testhead.Text = "";
            amount.Text = "";
            remarks.Text = "";
            errorProvider1.Clear();
            
        }

        private void pno_TextChanged(object sender, EventArgs e)
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

        private void amount_TextChanged(object sender, EventArgs e)
        {
            string text = amount.Text;
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

                errorProvider1.SetError(amount, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
