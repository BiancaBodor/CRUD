using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-ACP3GLEH\\SQLEXPRESS;Initial Catalog=App;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
           

            con.Open();

            SqlCommand command = new SqlCommand("insert into ProductInfo_Tab values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "', getdate(), getDate())", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted!");

            con.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update ProductInfo_Tab set ItemName= ' " + textBox2.Text + " ',Design=' " + textBox3.Text + " ', Color='" + comboBox1.Text + "' , UpdateDate = '" + DateTime.Parse(dateTimePicker1.Text)+ "' where  ProductID='" +int.Parse(textBox1.Text)+ "' ", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated!");
            BindData();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {




                con.Open();
                SqlCommand command = new SqlCommand("Delete ProductInfo_tab where ProductID='" + int.Parse(textBox1.Text) + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted!");
                BindData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab where ProductID='" + int.Parse(textBox1.Text)+"'", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
