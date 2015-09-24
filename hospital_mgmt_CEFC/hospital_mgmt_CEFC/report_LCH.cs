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
    public partial class report_LCH : Form
    {
        patient_LCH p = new patient_LCH();
        
        public report_LCH()
        {
            InitializeComponent();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
           
        }

        private void report_LCH_Load(object sender, EventArgs e)
        {
            
            label10.Text = search_LCH.pser.patientNo.ToString();
            label11.Text = search_LCH.pser.patientName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            test_LCH test = new test_LCH();
            test.Show();
            this.Hide();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check_LCH chk = new check_LCH();
            chk.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            chkreport_LCH chk = new chkreport_LCH();
            chk.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            testreport_LCH tr = new testreport_LCH();
            tr.Show();
            this.Hide();
        }


    }
}
