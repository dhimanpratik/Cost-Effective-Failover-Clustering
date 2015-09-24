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
    public partial class chkreport_LCH : Form
    {
        public chkreport_LCH()
        {
            InitializeComponent();
        }

        private void chkreport_LCH_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            CEFCServiceReference.Class_Checking[] t = new CEFCServiceReference.Class_Checking[30];
            CEFCServiceReference.Service1Client client = new CEFCServiceReference.Service1Client();

            label9.Text = search_LCH.pser.patientNo.ToString();
            t = client.FindChecksofPatient(search_LCH.pser.patientNo);
            if (t[1].remarks == "error")
            {
            }
            else
            {
                int n = client.returncheckcounter();

                //  CEFCServiceReference.Class_Test.
                dt.Columns.Add("Check Date", typeof(DateTime));
                dt.Columns.Add("Doc ID", typeof(int));
                dt.Columns.Add("Remarks", typeof(string));
                dt.Columns.Add("Fee", typeof(string));

                for (int i = 0; i < n; i++)
                {
                    dt.Rows.Add(new object[] { t[i].checkdate.Date, t[i].docID.ToString(), t[i].remarks.ToString(), t[i].fee.ToString() });
                }

                ds.Tables.Add(dt);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = dt.TableName;
                dataGridView1.Show();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            report_LCH report = new report_LCH();
            report.Show();
            this.Hide();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
