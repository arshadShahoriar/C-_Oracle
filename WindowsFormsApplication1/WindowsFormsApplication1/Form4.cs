using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        Registration x = new Registration();
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Registration one = new Registration();
            one.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form5 s = new Form5();
            s.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select * from car where C_Name='" + textBox1.Text + "' or C_Id='" + textBox1.Text + "'";
 
                OracleDataAdapter da = new OracleDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                // return dt;
            }
            catch (Exception exception)
            {
                MessageBox.Show("exception");
                //  return new DataTable();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
           
            try
                  {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select U_ID,U_NAME,ADDRESS,NAME,MOBILE_NO from CarShop_User ";
              
                OracleDataAdapter da = new OracleDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                
            }
            catch (Exception exception)
            {
                MessageBox.Show("exception");
               
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form2 p = new Form2();
            p.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Registration s = new Registration();
            //string id = user.getUserName();
            int p = s.getReturnID();

           // int s = x.getId();
           if (p > 10)
            {
                panel2.Visible = false;
            }
             if (p != 1)
            {
                label10.Visible = false;
                label12.Visible = false;

         }
            //else if(s ==1)
              //  label10.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form6 s = new Form6();
            s.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form7 s = new Form7();
            s.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Registration s = new Registration();
            //  string id = user.getUserName();
            int p = s.getReturnID();
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select * from user_history where U_ID= '"+p+"'";

                OracleDataAdapter da = new OracleDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;



            }
            catch (Exception exception)
            {
                MessageBox.Show("exception");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form8 s = new Form8();
            s.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select * from user_history ";

                OracleDataAdapter da = new OracleDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;



            }
            catch (Exception exception)
            {
                MessageBox.Show("exception");

            }

        }
    }
}
