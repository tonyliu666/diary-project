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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string year = dateTimePicker1.Value.Year.ToString();
                string month = dateTimePicker1.Value.Month.ToString();
                string day = dateTimePicker1.Value.Day.ToString();
                string intebody = "";
                Stream.Read(year, month, day, "<title>", "</title>", out string[] title);
                Stream.Read(year, month, day, "<weather>", "</weather>", out string[] weather);
                Stream.Read(year, month, day, "<body>", "</body>", out string[] body);
                for (int i = 0; i < 10; i++)
                {
                    intebody = intebody + "\n" + body[i];
                }
                richTextBox1.Text = title[0] + "\n" + weather[0] + intebody;
            }
            catch (Exception)
            {
                richTextBox1.Text =  "今日無內容。";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //**************************************
            Edit edit = new Edit(dateTimePicker1.Value.Year.ToString(), dateTimePicker1.Value.Month.ToString(), dateTimePicker1.Value.Day.ToString());
            edit.ShowDialog();
            //**************************************
        }
    }
}
