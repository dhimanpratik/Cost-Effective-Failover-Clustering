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
    public partial class Form1 : Form
    {
        string s1, s2, s3, s4, s5, s6;
        int cnt = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\password.txt");

           //MessageBox .Show(lines[0]+lines[1]+lines[2]);
   
            
           
            if (uname.Text.Equals(lines [0])  && pass.Text.Equals(lines[0] ))
            {
               patient_LCH  pat = new patient_LCH ();
                pat.Show();
                this.Close();
                
 
            }
            else if (uname.Text.Equals(lines [1])  && pass.Text.Equals(lines[1] ))
            {
               search_LCH   src=new search_LCH  ();
                src.Show();
                this.Close();    
                
            }
            else if (uname.Text.Equals(lines[2]) && pass.Text.Equals(lines[2]))
            {
                option_LCH  opn= new option_LCH ();
                opn.Show();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("PLEASE CHECK USERNAME AND PASSWORD!!!", "LIFECARE");

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uname.Text = "";
            pass.Text = "";
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
 
 
        }
    }
}
