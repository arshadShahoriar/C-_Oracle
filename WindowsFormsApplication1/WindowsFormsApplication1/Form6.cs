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
    public partial class Form6 : Form
    {
      //  Registration one = new Registration();
        UserClass user = new UserClass();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            //  string car_AVAILABILITY = dt.Rows[0]["AVAILABILITY"].ToString();
            Registration s = new Registration();
            string id = user.getUserName();
            int p = s.getReturnID();

            textBox2.Text = p.ToString();





            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();
            string query = "select * from CarShop_User where U_ID= '" + p + "' ";
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
                string pass = dt.Rows[0]["U_PASSWORD"].ToString();
                string u_address = dt.Rows[0]["ADDRESS"].ToString();
                string city = dt.Rows[0]["Name"].ToString();
                string mobile = dt.Rows[0]["MOBILE_NO"].ToString();

                textBox1.Text = u_id.ToString();
                textBox2.Text = u_name;
                textBox3.Text = u_address;
                textBox4.Text = city;
                textBox5.Text = mobile;
                textBox6.Text = pass;


            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // string k = textBox4.Text;
            // string l = textBox3.Text;
           // int c_price = Int32.Parse(k);
            //int c_avail = Int32.Parse(l);
            Registration s = new Registration();
            string id = user.getUserName();
            int p = s.getReturnID();

            string query ="call updateUser('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
           // string query = "update CarShop_User set U_ID='" + textBox1.Text + "',U_NAME='" + textBox2.Text + "',U_PASSWORD='" + textBox6.Text + "',ADDRESS='" + textBox3.Text + "',NAME='"+ textBox4.Text +"',MOBILE_NO='"+ textBox5.Text +"' where U_ID='" + p + "' ";

            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();

            OracleCommand cmd = new OracleCommand(query, con);
            OracleDataReader dr = cmd.ExecuteReader();
            // int row = cmd.ExecuteNonQuery();
            if (dr.Read())
            {
                MessageBox.Show("updated");
                con.Close();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            a.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
