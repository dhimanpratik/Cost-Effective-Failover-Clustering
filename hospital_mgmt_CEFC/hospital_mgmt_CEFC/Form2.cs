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
    public partial class Form2 : Form
    {
        Form1 obj = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Interval = 20;
            if (progressBar1.Value != 100)
            {

                progressBar1.Value = progressBar1.Value + 1;
                switch (progressBar1.Value)
                {
                    case 10:
                        label2.Text = "loading your settings Please wait......";
                        label1.Visible  = true;
                        break;
                    case 20:
                        label2.Text = "loading doc.img";
                        label3.Visible  = true;
                        break;
                    case 30:
                        label2.Text = "loading exit.img";
                        label4.Visible  = true;
                        break;
                    case 40:
                        label2.Text = "loading update.img";
                        label5.Visible  = true;
                        break;
                    case 50:
                        label2.Text = "loading exit.img";
                        label6.Visible  = true;
                        break;
                    case 60:
                        label2.Text = "loading your settings Please wait......";
                        label7.Visible  = true;
                        break;
                    case 80:
                        label2.Text = "loading other components.";
                        label8.Visible  = true;
                        break;
                    case 90:
                        label2.Text = "Connecting to service";
                        label9.Visible  = true;
                        break;
                    case 100:
                        label2.Text = "DONE!!!";
                        label1.Enabled = false;
                        break;

                }

            }
            else
            {
                try
                {
                    obj.Show();
                    this.Hide();
                }
                catch (ObjectDisposedException)
                {
                    

                }
            
                //timer1.Enabled = false;


            }
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = " ";
            label1.Visible  = false;
            label3.Visible  = false;
            label4.Visible  = false;
            label5.Visible  = false;
            label6.Visible  = false;
            label7.Visible  = false;
            label8.Visible  = false;
            label9.Visible  = false;
            progressBar1.Visible = false;
 
        }
    }
}
