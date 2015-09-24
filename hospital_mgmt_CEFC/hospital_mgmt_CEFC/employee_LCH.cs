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
    public partial class employee_LCH : Form
    {
       public  CEFCServiceReference.Service1Client obj = new CEFCServiceReference.Service1Client();
        CEFCServiceReference.Class_Employee emp = new CEFCServiceReference.Class_Employee();
        public employee_LCH()
        {
            InitializeComponent();
        }

        private void SUBMIT_Click(object sender, EventArgs e)
        {
            emp.empID = Convert.ToInt32(empid.Text);
            emp.empName = empname.Text;
            emp.counterNo = Convert.ToInt32(counterid.Text);
            obj.InsertNewEmployee(emp);
            MessageBox.Show("RECORD ADDED SUCCESSFULLY!!!", "LIFECARE");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            option_LCH op = new option_LCH();
            op.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = empid.Text;
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

                errorProvider1.SetError(empid, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            empid.Text = "";
            empname.Text = "";
            counterid.Text = "";
            errorProvider1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void counterid_TextChanged(object sender, EventArgs e)
        {
            string text = counterid.Text;
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

                errorProvider1.SetError(counterid, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
