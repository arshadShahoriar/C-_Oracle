
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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 s = new Form4();
            s.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
           // textBox1.Read() = true;
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select c.*,s.U_SAL,s.U_COMM from CarShop_User c,CarShop_Sal s  where c.u_id>1 and  c.u_id<11 and c.U_ID=s.U_ID" ;

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();
            string query = "select * from CarShop_Sal where U_ID= '" + textBox2.Text + "' ";
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
                int u_id = Int32.Parse(dt.Rows[0]["U_ID"].ToString());
                string u_name = dt.Rows[0]["U_NAME"].ToString();
                int u_sal = Int32.Parse(dt.Rows[0]["U_SAL"].ToString());
                int u_comm = Int32.Parse(dt.Rows[0]["U_COMM"].ToString());
              //  string city = dt.Rows[0]["Name"].ToString();
               // string mobile = dt.Rows[0]["MOBILE_NO"].ToString();

                textBox2.Text = u_id.ToString();
                textBox1.Text = u_name;
                textBox3.Text = u_sal.ToString();
                textBox4.Text = u_comm.ToString();
                


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query= "Call UpdateSal('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
         //   string query = "update CarShop_Sal set U_ID='" + textBox2.Text + "',U_NAME='" + textBox1.Text + "',U_SAL='" + textBox3.Text + "',U_COMM='" + textBox4.Text + "' where U_ID='"+ textBox2.Text +"'";

           // string query2 = "update CarShop_User set U_NAME='" + textBox1.Text + "' where U_ID='" + textBox2.Text + "'";

            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader dr = cmd.ExecuteReader();

         //   OracleCommand cmd2 = new OracleCommand(query2, con);
           // OracleDataReader dr2 = cmd.ExecuteReader();
            // int row = cmd.ExecuteNonQuery();
            if( (dr.Read()))
            {
                MessageBox.Show("updated");
                con.Close();
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "Delete from CarShop_User where U_ID=" + textBox2.Text + "";
            string query2 = "Delete from CarShop_Sal where U_ID=" + textBox2.Text + "";


           


            OracleConnection con2 = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con2.Open();

            OracleCommand cmd2 = new OracleCommand(query2, con2);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            // int row = cmd.ExecuteNonQuery();
            if (dr2.Read())
            {
                MessageBox.Show("Inserted");
                con2.Close();
            }

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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
                con.Open();
                string query = "select c.*,s.U_SAL,s.U_COMM from CarShop_User c,CarShop_Sal s  where c.u_id>1 and  c.u_id<11 and c.U_ID=s.U_ID";

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
