using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace БД_Денис
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Clear();

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\БД\БД Денис\БД Денис\Database1.mdf;Integrated Security=True;");
            sqlConnection.Open();

            adapter = new SqlDataAdapter("SELECT * FROM polka", sqlConnection);

            table = new DataTable();
            adapter.Fill(table);
            label1.Text += table.Rows.Count.ToString();
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            table.Clear();

            adapter.Fill(table);
            var count = table.Rows.Count;
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотитет удалить запись " + "?", "", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\БД\БД Денис\БД Денис\Database1.mdf;Integrated Security=True;");
                sqlConnection.Open();

                {
                    try
                    {
                        SqlCommand Deleted = new SqlCommand();
                        Deleted.Connection = sqlConnection;
                        Deleted.CommandText = "Delete from polka Where Id=@Id";
                        Deleted.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                        Deleted.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    catch (SqlException ex)
                    { MessageBox.Show(ex.Message); }
                    table.Clear();

                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }

        }

        private void тёмнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.BackColor = System.Drawing.Color.DarkGray;
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
            dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.DarkGray;
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.BackColor = System.Drawing.Color.LightSlateGray;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
        }

        private void курсВалютToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
        }
    }
}
