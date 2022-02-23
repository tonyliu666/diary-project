using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 讀寫日記_期末專題_
{
    public partial class Edit : Form
    {//***********************
        private string[] time = new string[3];
        //************************
        public string[] Time
        {
            get { return time; }
            set { time=value; }
        }

        public Edit(string year, string month, string day)
        {
            InitializeComponent();
            this.time[0] = year;
            this.time[1] = month;
            this.time[2] = day;
        }
       



        private void button1_Click(object sender, EventArgs e)
        {   //**************************************
            Stream.Write(time[0] , time[1] , time[2], textBox1.Text, (string)comboBox1.Items[comboBox1.SelectedIndex], richTextBox1.Text);
            Form1 edit = new Form1();

            Dispose();

            //**************************************
        }

        private void 取消_Click(object sender, EventArgs e)
        {//*****************************************
            Form1 edit = new Form1();
            Dispose();
            //**************************************
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_BackColorChanged(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.Red;

        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {//************************************************
            
                //******************************************************
            }
    }
}
