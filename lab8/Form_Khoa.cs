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
using System.Data;
using System.Data.SqlTypes;

namespace lab8
{
    public partial class Form_Khoa : Form
    {
        SqlConnection cnn;
        SqlConnection cnnsql;
        public Form_Khoa()
        {
            InitializeComponent();
            cnn = new SqlConnection(@"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=ilaaa;Integrated Security=True");
            cnnsql = new SqlConnection(@"Data Source=LAPTOP-77AKUU80\SQLEXPRESS;Initial Catalog=ilaaa;User ID = admin; Password = 123");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(cnnsql.State ==  ConnectionState.Closed)
                {
                    cnnsql.Open();
                }
                string insertString;
                insertString = "insert into Khoa values('" + txb_MaKh.Text + "', N'" + txb_TenKh.Text + "')";
                SqlCommand cmd = new SqlCommand(insertString, cnnsql);
                cmd.ExecuteNonQuery();
                if(cnnsql.State == ConnectionState.Open)
                {
                    cnnsql.Close();
                }
                MessageBox.Show("Thanh cong!"); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnnsql.State == ConnectionState.Closed)
                {
                    cnnsql.Open();
                }
                string updateString;
                updateString = "update Khoa set TenKhoa='" + txb_TenKh.Text + "' where Makhoa ='" + txb_MaKh.Text + "'";
                SqlCommand cmd = new SqlCommand(updateString, cnnsql);
                cmd.ExecuteNonQuery();
                if (cnnsql.State == ConnectionState.Open)
                {
                    cnnsql.Close();
                }
                MessageBox.Show("Thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cnnsql.State == ConnectionState.Closed)
                {
                    cnnsql.Open();
                }
                string deleteString;
                deleteString = "delete Khoa where MaKhoa='" + txb_MaKh.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteString, cnnsql);
                cmd.ExecuteNonQuery();
                if (cnnsql.State == ConnectionState.Open)
                {
                    cnnsql.Close();
                }
                MessageBox.Show("Thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }
    }
}
