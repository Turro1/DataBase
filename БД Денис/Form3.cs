using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using БД_Денис.Properties;

namespace БД_Денис
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = Settings.Default["grn"].ToString();
            textBox2.Text = Settings.Default["dol"].ToString();
            textBox3.Text = Settings.Default["lei"].ToString();
            textBox4.Text = Settings.Default["evr"].ToString();
            string grn = Settings.Default["grn"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Settings.Default["grn"] = textBox1.Text;
            Settings.Default["dol"] = textBox2.Text;
            Settings.Default["lei"] = textBox3.Text;
            Settings.Default["evr"] = textBox4.Text;
            string grn = Settings.Default["grn"].ToString();
            Settings.Default.Save();
        }
    }
}
