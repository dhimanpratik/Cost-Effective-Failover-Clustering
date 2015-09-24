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
    public partial class testreport_LCH : Form
    {

        public testreport_LCH()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            report_LCH r = new report_LCH();
            r.Show();
            

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
            this.Close();

        }
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private void testreport_LCH_Load(object sender, EventArgs e)
        {
           
            CEFCServiceReference.Class_Test[] t = new CEFCServiceReference.Class_Test[30];
            CEFCServiceReference.Service1Client client = new CEFCServiceReference.Service1Client();
            
            label10.Text = search_LCH.pser.patientNo.ToString();
            t = client.FindTestsofPatient(search_LCH.pser.patientNo);
            
            if(t[1].remarks == "error")
            {
                MessageBox.Show("Couldn't connect to any database at the moment");
            }
            else
            {
            int n = client.returntestcounter();            

          //  CEFCServiceReference.Class_Test.
            dt.Columns.Add("Test Date", typeof(DateTime));
            dt.Columns.Add("Test Head", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            for (int i = 0; i < n; i++)
            {
                dt.Rows.Add(new object[] {t[i].testdate.Date,t[i].testhead.ToString(),t[i].remarks.ToString(),t[i].amount.ToString()});
            }



            ds.Tables.Add(dt);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = dt.TableName;
            dataGridView1.Show();
            }
        }

    }
}
