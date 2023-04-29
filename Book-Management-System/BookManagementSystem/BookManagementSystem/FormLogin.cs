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

namespace BookManagementSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " select * from UserDetails Where UserName = '" + this.txtUserName.Text + "' and Password = '" + this.txtPassword.Text + "' ";
                SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-45AAEFS\MR;Initial Catalog=vstringdb;Persist Security Info=True;User ID=sa;Password=efaj1234");
                sqlCon.Open();
                SqlCommand sqlCom = new SqlCommand(sql, sqlCon);
                SqlDataAdapter sdAdapter = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                sdAdapter.Fill(ds);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("Login valid");
                    if (ds.Tables[0].Rows[0][2].ToString().Equals("Interior Minister"))
                    {
                        FormInteriorMinister fim = new FormInteriorMinister();
                        fim.Visible = true;
                    }

                    else if (ds.Tables[0].Rows[0][2].ToString().Equals("Jailer"))
                    {
                        FormJailer fj = new FormJailer();
                        fj.Visible = true;
                    }

                    else if (ds.Tables[0].Rows[0][2].ToString().Equals("Lawyer"))
                    {
                        FormLawyer fl = new FormLawyer();
                        fl.Visible = true;
                    }
                

                }
                else
                {
                    MessageBox.Show("Login invalid");
                }
                sqlCon.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error:" + exc.Message);

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            this.btnLogin.BackColor = Color.DarkGreen;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            this.btnLogin.BackColor = Color.Blue;
          
        }
    }
}
