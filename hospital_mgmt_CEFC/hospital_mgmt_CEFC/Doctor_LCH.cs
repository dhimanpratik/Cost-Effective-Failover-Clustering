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
    public partial class Doctor_LCH : Form
    {
        CEFCServiceReference.Service1Client doc = new CEFCServiceReference.Service1Client();
        CEFCServiceReference.Class_Doctor doc1 = new CEFCServiceReference.Class_Doctor();
        public Doctor_LCH()
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc1.docID = Convert.ToInt32(docid.Text);
            doc1.docName = dname.Text;
            doc1.contact = dcontact.Text;
            doc1.faculty = dfaculty.Text;
            doc1.address = daddr.Text;
            doc.InsertNewDoctor(doc1);
            MessageBox.Show("RECORD ADDED SUCCESSFULLY!!!", "LIFECARE");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            option_LCH o = new option_LCH();
            o.Show();
            this.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dname.Text = "";
            daddr.Text = "";
            docid.Text = "";
            dcontact.Text = "";
            dfaculty.Text = "";
            errorProvider1.Clear();
        }

        private void dcontact_TextChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            string text = dcontact.Text;
            bool hasDigit = false;
            int flag=0;
            foreach (char letter in text)
            {
                cnt++;
                if (cnt > 10)
                {
                    flag=1;
                    break;
                }

            }
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

                errorProvider1.SetError(dcontact, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (flag == 1)
            {
                errorProvider1.SetError(dcontact, "Check your mobile number");
            }

        }

        private void docid_TextChanged(object sender, EventArgs e)
        {
            string text = docid.Text;
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

                errorProvider1.SetError(docid, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }
           
        }
    }
}
