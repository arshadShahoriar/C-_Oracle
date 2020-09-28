
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
    public partial class Registration : Form
    {
        UserClass user = new UserClass();
      
        public static int k;
     

        OracleConnection con = null;
       
        

        public Registration()
        {

            InitializeComponent();
        }
       public int getReturnID() {

            return k;
        }
      

        OracleConnection conn = new OracleConnection("DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=CAR_SHOPDB;PASSWORD=123");
        private void btnSignIn_Click(object sender, EventArgs e)
        {

            conn.Open();

            string query = "select U_ID,U_NAME from CarShop_User where U_PASSWORD=" + txtU_Pass.Text + " and U_ID=" + txtU_Name.Text + " ";



            OracleCommand cmd = new OracleCommand(query, conn);


            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                DataSet ds = new DataSet();
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count != 1)
                {
                    
                    return;
                }
             
               int u_id = Int32.Parse(dt.Rows[0]["U_ID"].ToString());
                string u_name = dt.Rows[0]["U_NAME"].ToString();
             
                k = u_id;
              //  user.setId(u_id);
               // user.setUserName(u_name);

                
                Form4 s = new Form4();
                s.Show();

                this.Hide();
              


            }
            else
                MessageBox.Show("Incorrect UserId/Password ");
            conn.Close();
        }
     

        private void button1_Click(object sender, EventArgs e)
        {

            Form3 x = new Form3();
             x.Show();
            this.Hide();
            
           
           // this.Close();

        }
    }
}
