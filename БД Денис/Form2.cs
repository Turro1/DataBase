using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using БД_Денис.Properties;

namespace БД_Денис
{
    public partial class Form2 : Form
    {
        public SqlConnection sqlConnection = null;
        public SqlDataAdapter adapter = null;
        public DataTable table = null;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string grn1 = Settings.Default["grn"].ToString();
            int gr1 = Convert.ToInt32(grn1);
            string s = textBox1.Text; 
            int nt = Convert.ToInt32(textBox2.Text);
            string tn = textBox3.Text;
            string fio = textBox4.Text;
            string add = textBox5.Text;
            string sod = textBox6.Text;
            int grn = Convert.ToInt32(textBox7.Text);
            int stdos = Convert.ToInt32(textBox8.Text);
            int a = (grn*gr1) + stdos;
            a.ToString();
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\БД\БД Денис\БД Денис\Database1.mdf;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO polka VALUES(@s, @nt, @tn, @fio, @add, @sod, @grn, @stdos, " +a+ ")", sqlConnection);
           
            command.Parameters.Add("@s", SqlDbType.NVarChar).Value = textBox1.Text;
            command.Parameters.Add("@nt", SqlDbType.Int).Value = textBox2.Text;
            command.Parameters.Add("@tn", SqlDbType.NVarChar).Value = textBox3.Text;
            command.Parameters.Add("@fio", SqlDbType.NVarChar).Value = textBox4.Text;
            command.Parameters.Add("@add", SqlDbType.NVarChar).Value = textBox5.Text;
            command.Parameters.Add("@sod", SqlDbType.NVarChar).Value = textBox6.Text;
            command.Parameters.Add("@grn", SqlDbType.Int).Value = textBox7.Text;
            command.Parameters.Add("@stdos", SqlDbType.Int).Value = textBox8.Text;

            MessageBox.Show("Запись успешно добавлена!");

            adapter = new SqlDataAdapter(command);

            table = new DataTable();
            adapter.Fill(table);

            sqlConnection.Close();
        }
    }
}
