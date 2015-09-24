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
    public partial class doctordisplay_LCH : Form
    {
        public doctordisplay_LCH()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test_LCH test = new test_LCH();
            test.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            check_LCH chk = new check_LCH();
            chk.Show();

        }
    }
}
