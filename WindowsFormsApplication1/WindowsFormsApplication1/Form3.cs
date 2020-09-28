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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
       
       // OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
        private void button1_Click(object sender, EventArgs e)
        {/*
            conn.Open();
          

            string query = "Insert into Customer(U_ID,U_NAME,U_PASSWORD,ADDRESS,NAME,MOBILE_NO) values('" + textBox1.Text+ "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "'";
            OracleCommand cmd = new OracleCommand(query, conn);

            OracleDataReader dr = cmd.ExecuteReader();
            //int rowsUpdated = cmd.ExecuteNonQuery();

            if (dr.Read())
            {
                MessageBox.Show("Record  inserted");


                this.Hide();
                Form4 x = new Form4();
                x.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Record not inserted");


                
            }

           */
            string query = "call InsertUser('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "')";
            

           // string query = "INSERT INTO CarShop_User VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "')";
            


            OracleConnection con = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
            con.Open();

            OracleCommand cmd = new OracleCommand(query, con);
            try
            {
                OracleDataReader dr = cmd.ExecuteReader();
                // int row = cmd.ExecuteNonQuery();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted");
                    con.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                     textBox5.Text = "";
                    textBox6.Text = "";
                    // textBox7.Text = "";
                    // textBox8.Text = "";
                    // textBox9.Text = "";
                }
                MessageBox.Show("Inserted");
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            catch(Exception ex){

                MessageBox.Show("Used different ID");
                con.Close();
            
            }
            /*
            OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
//OracleConnection conn = new OracleConnection("User Id=scott;Password=tiger;Server=OraServer;");
//OracleCommand cmd = new OracleCommand();

          cmd.CommandText = "Insert into Customer(U_ID,U_NAME,U_PASSWORD,ADDRESS,NAME,MOBILE_NO) values('"+ textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "'";
      //   cmd.CommandText=   "Insert into Customer(U_ID,U_NAME,U_PASSWORD,ADDRESS,NAME,MOBILE_NO) values('2','+"rshad"+','+"saidpur"+','"+a+"','"+ss+"','11') ";
 
            cmd.Connection = conn;
conn.Open();
try {
  int aff = cmd.ExecuteNonQuery();
  MessageBox.Show(aff + " rows were affected.");
}
catch {
  MessageBox.Show("Error encountered during INSERT operation.");
}
finally {
  conn.Close();
}
               * */
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration x = new Registration();
            x.ShowDialog();
            this.Close();
        }
    }
}
