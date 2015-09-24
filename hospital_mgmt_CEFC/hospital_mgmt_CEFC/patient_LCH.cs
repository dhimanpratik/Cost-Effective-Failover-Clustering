using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace hospital_mgmt_CEFC
{
    public partial class patient_LCH : Form
    {
        CEFCServiceReference.Service1Client obj = new CEFCServiceReference.Service1Client();
        
        
        public patient_LCH()
        {
            
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void patient_LCH_Load(object sender, EventArgs e)
        {

            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string text = pempid.Text;
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

                errorProvider1.SetError(pempid, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           CEFCServiceReference.Class_Patient p = new CEFCServiceReference.Class_Patient();
           pno.Text= Microsoft.VisualBasic.Interaction.InputBox("Enter patient ID", "LIFECARE");
           p=obj.Find(Convert.ToInt32(pno.Text));
           pname.Text = p.patientName;
           pno.Text = Convert.ToString(p.patientNo);
           page.Text = Convert.ToString(p.Page);
           dateTimePicker1.Text = Convert.ToString(p.PdisDate);
           dateTimePicker2.Text = Convert.ToString(p.PregDate);
           pempid.Text = Convert.ToString(p.PempID);
           paddr.Text = p.Paddress;
           premarks.Text = p.Premarks;

         


           if (p.Psex == "Male")
           {
               radioButton1.Checked = true;

           }
           else
           {
               radioButton2.Checked = true;
           }

           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CEFCServiceReference.Class_Patient p = new CEFCServiceReference.Class_Patient();
            p.patientNo = Convert.ToInt32(pno.Text);
            p.patientName = pname.Text;
            p.Page = Convert.ToInt32(page.Text);
            if (radioButton1.Checked == true)
            {
                p.Psex = radioButton1.Text;
            }
            else
            {
                p.Psex = radioButton2.Text;

            }
            p.Paddress = paddr.Text;
            p.PdisDate = Convert.ToDateTime(dateTimePicker1.Text).Date;//ToString("dd/MM/yyyy");
            p.PempID = Convert.ToInt32(pempid.Text);
            p.Premarks = premarks.Text;
            p.PregDate = Convert.ToDateTime(dateTimePicker2.Text).Date;


            MessageBox.Show(obj.InsertNewPatients(p));

            

           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
        private void textBox1_Validating(object sender, EventArgs e)
        {
           
            
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string text = page.Text;
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

                errorProvider1.SetError(page, "PLZ ENTER DIGITS ONLY");
            }
            else
            {
                errorProvider1.Clear();
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            pno.Text = "";
            pname.Text = "";
            page.Text = "";
            paddr.Text = "";
          
            premarks.Text = "";
            pempid.Text = "";
            errorProvider1.Clear();

            
        }

        private void pupdate_Click(object sender, EventArgs e)
        {
            CEFCServiceReference.Class_Patient p = new CEFCServiceReference.Class_Patient();
            p.patientNo = Convert.ToInt32(pno.Text);
            p.patientName = pname.Text;
            p.Page = Convert.ToInt32(page.Text);
            if (radioButton1.Checked == true)
            {
                p.Psex = radioButton1.Text;
            }
            else
            {
                p.Psex = radioButton2.Text;

            }
            p.Paddress = paddr.Text;
            p.PdisDate = Convert.ToDateTime(dateTimePicker1.Text).Date;//ToString("dd/MM/yyyy");
            p.PempID = Convert.ToInt32(pempid.Text);
            p.Premarks = premarks.Text;
            p.PregDate = Convert.ToDateTime(dateTimePicker2.Text).Date;

            MessageBox.Show(obj.UpdatePatient(p));
        }
    }
}
