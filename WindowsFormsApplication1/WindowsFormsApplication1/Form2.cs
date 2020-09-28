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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 s = new Form4();
            s.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select * from Car ";

                OracleDataAdapter da = new OracleDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataFineView.DataSource = dt;



            }
            catch (Exception exception)
            {
                MessageBox.Show("exception");

            }
        }

        private void dataFineView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select * from car where C_ID='" + textBox2.Text + "' ";
                OracleCommand cmd = new OracleCommand(query, con);
                DataSet ds = new DataSet();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

               
            
          
          //  DataTable dt = DataAccess.LoadData("select * from UserInfo where UserName='" + txtUN.Text +
                                       //        "' and Password='" + txtPassword.Text + "'");

            if (dt.Rows.Count != 1)
            {
              //  MessageBox.Show("Invalid CarID");
                return;
            }

           
            string car_name= dt.Rows[0]["C_NAME"].ToString();
            int car_price = Int32.Parse(dt.Rows[0]["PRICE"].ToString());
            string car_model = dt.Rows[0]["MODEL"].ToString();
            string car_AVAILABILITY = dt.Rows[0]["AVAILABILITY"].ToString();
            int bookedid = Int32.Parse(dt.Rows[0]["BOOKED_ID"].ToString());
            int m_id = Int32.Parse(dt.Rows[0]["M_ID"].ToString());
            int o_id = Int32.Parse(dt.Rows[0]["O_ID"].ToString());
            int u_id = Int32.Parse(dt.Rows[0]["U_ID"].ToString());
            
            
            textBox1.Text = car_name;
            
            textBox4.Text = car_price.ToString();
            textBox5.Text = car_model;
            textBox3.Text = car_AVAILABILITY;

            textBox6.Text = bookedid.ToString();
            textBox8.Text = m_id.ToString();
            textBox7.Text = o_id.ToString();
            textBox9.Text = u_id.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string k = textBox4.Text;
           // string l = textBox3.Text;
            int c_price = Int32.Parse(k);
            //int c_avail = Int32.Parse(l);

            string query = "update Car set C_NAME='" + textBox1.Text + "',PRICE='" + c_price + "',MODEL='" + textBox5.Text + "',AVAILABILITY='" + textBox3.Text + "'  where C_ID='" + textBox2.Text + "' ";

            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader dr = cmd.ExecuteReader();
           // int row = cmd.ExecuteNonQuery();
            if (dr.Read()){
                MessageBox.Show("updated");
                con.Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select * from Car ";

                OracleDataAdapter da = new OracleDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataFineView.DataSource = dt;



            }
            catch (Exception exception)
            {
                MessageBox.Show("exception");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string query = "update Car set C_NAME='" + textBox1.Text + "',PRICE='" + c_price + "',MODEL='" + textBox5.Text + "',AVAILABILITY='" + textBox3.Text + "'  where C_ID='" + textBox2.Text + "' ";
            string query = "INSERT INTO car VALUES ('" + textBox2.Text + "' , '" + textBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox3.Text + "', '" + textBox6.Text + "', '" + textBox8.Text + "', '" + textBox7.Text + "', '" + textBox9.Text + "')";


            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();
            try
            {
                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader dr = cmd.ExecuteReader();
                // int row = cmd.ExecuteNonQuery();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted");
                    con.Close();
                }
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
            }
            catch (Exception Ex) { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form4 s = new Form4();
            s.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "Delete from car where C_ID='"+textBox2.Text+"'";
            

            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader dr = cmd.ExecuteReader();
            // int row = cmd.ExecuteNonQuery();
            if (dr.Read())
            {
                MessageBox.Show("Deleted");
                con.Close();
            }
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
