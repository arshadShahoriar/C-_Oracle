
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select C_ID,C_NAME,PRICE,MODEL,AVAILABILITY from car";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();
            string query = "select C_ID,C_NAME,PRICE,AVAILABILITY from car where C_ID= '" + textBox1.Text + "' ";
            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                DataSet ds = new DataSet();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid CarID");
                    return;
                }
                //   string u_id = dt.Rows[0]["U_ID"].ToString();
                int u_id = Int32.Parse(dt.Rows[0]["C_ID"].ToString());
                string u_name = dt.Rows[0]["C_NAME"].ToString();
                string price = dt.Rows[0]["PRICE"].ToString();
                string AVAILABILITY = dt.Rows[0]["AVAILABILITY"].ToString();
                

                textBox1.Text = u_id.ToString();
                textBox2.Text =  u_name;
                textBox3.Text =price;
                textBox4.Text =AVAILABILITY;
                


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration s = new Registration();
            //  string id = user.getUserName();
            int p = s.getReturnID();

            string query = "INSERT INTO user_history VALUES ('" + textBox6.Text + "' , '" + p + "', '" + textBox1.Text + "', '" + "yes" + "', '" + "nO" + "', '" + textBox3.Text + "')";


            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
           try{
            con.Open();

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
                // textBox5.Text = "";
                textBox6.Text = "";
                // textBox7.Text = "";
                // textBox8.Text = "";
                // textBox9.Text = "";
            }
           catch (Exception ex)
           {

               MessageBox.Show("used id correctly");
           }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration s = new Registration();
            //  string id = user.getUserName();
            int p = s.getReturnID();
            try
            {
                string query = "INSERT INTO user_history VALUES ('" + textBox6.Text + "' , '" + p + "', '" + textBox1.Text + "', '" + "no" + "', '" + "yes" + "', '" + textBox3.Text + "')";


                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();

                OracleCommand cmd = new OracleCommand(query, con);
                OracleDataReader dr = cmd.ExecuteReader();
                // int row = cmd.ExecuteNonQuery();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted");
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex) {
               

                MessageBox.Show("used id correctly");
                
            }
           // con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            // textBox5.Text = "";
            textBox6.Text = "";
            // textBox7.Text = "";
            // textBox8.Text = "";
            // textBox9.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 s = new Form4();
            s.Show();
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        

        }
    }
}
