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
    public partial class check_LCH : Form
    {
        public check_LCH()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            report_LCH r = new report_LCH();
            r.Show();
            this.Close();

        }

        private void check_LCH_Load(object sender, EventArgs e)
        {
            cc = new CEFCServiceReference.Class_Checking();
            pno.Text = search_LCH.pser.patientNo.ToString();
        }
        CEFCServiceReference.Class_Checking cc;
        CEFCServiceReference.Service1Client client = new CEFCServiceReference.Service1Client();

        private void button1_Click(object sender, EventArgs e)
        {
            cc.patientNo = Convert.ToInt32(pno.Text);
            cc.docID = Convert.ToInt32(docid.Text);
            cc.checkdate = Convert.ToDateTime(dateTimePicker1.Text).Date;
            cc.fee = fee.Text;
            cc.remarks = remarks.Text;
            client.InsertNewChecking(cc);
            MessageBox.Show("RECORD ADDED SUCCESSFULLY!!!", "LIFECARE");
        }
    }
}
