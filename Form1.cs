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
namespace quanlythongtin1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con=new SqlConnection(@"Date Source=LAB1-MAY22\\MISASME2022;Initial Catalog=quanlythongtin;Integrated Security=True");
        private void openCon()
        {
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void closeCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            openCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd,con);
                sc.ExecuteNonQuery();
                check= true;
            }
            catch (Exception)
            {
                check = false;
                throw;
            }
            closeCon();
            return check;
        }
        private DataTable Red(string cmd)
        {
            openCon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc= new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                throw;
            }
            closeCon();
            return dt;
        }
        private void load()
        {
            DataTable dt =  Red("SELECT* FROM quanlythongtin");
            if(dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
           private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
