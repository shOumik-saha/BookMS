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
    
    public partial class FormExistedRecords : Form
    {
        private DataAccess Da { get; set; }
        public FormExistedRecords()
        {
            InitializeComponent();
            this.Da = new DataAccess();
           
        }

        private void PopulateGridView(string sql = " select * from Books_Records;")
        {
            try
            {
                DataSet ds = this.Da.ExecuteQuery(sql);

                this.dgvERecords.AutoGenerateColumns = false;
                this.dgvERecords.DataSource = ds.Tables[0];

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from Book_Records where BookName = '" + this.txtSearch.Text + "'; ";
            this.PopulateGridView(sql);
        }

        

        

        private void dgvERecords_DoubleClick(object sender, EventArgs e)
        {
            this.txtBookName.Text = this.dgvERecords.CurrentRow.Cells["BookName"].Value.ToString();
            this.txtBookPName.Text = this.dgvERecords.CurrentRow.Cells["BookPathersName"].Value.ToString();
            this.dtpDOB.Text = this.dgvERecords.CurrentRow.Cells["DateOfBirth"].Value.ToString();
            this.rtxtBookPageN.Text = this.dgvERecords.CurrentRow.Cells["BookPageN"].Value.ToString();
            this.dtpPublishDate.Text = this.dgvERecords.CurrentRow.Cells["PublishDate"].Value.ToString();
            this.txtBookType.Text = this.dgvERecords.CurrentRow.Cells["BookType"].Value.ToString();
            this.txtBookName.ReadOnly = true;
        }

       

        private void ClearContent()
        {
            this.txtBookName.Text = "";
            this.txtBookPName.Text = "";
            this.dtpDOB.Text = "";
            this.rtxtBookPageN.Text = "";
            this.dtpPublishDate.Text = "";
            this.txtBookType.Text = "";
            this.txtBookName.ReadOnly = true;




        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtBookName.Text) ||
                    String.IsNullOrEmpty(this.txtBookPName.Text) || String.IsNullOrEmpty(this.dtpDOB.Text) || String.IsNullOrEmpty(this.rtxtBookPageN.Text) ||
                    String.IsNullOrEmpty(this.dtpPublishDate.Text) || String.IsNullOrEmpty(this.txtBookType.Text))
                {
                    MessageBox.Show("To add Book Records please fill all the information.");
                    return;
                }


                var sql = "select * from Book_Records where BookName = '" + this.txtBookName.Text + "';";
                var ds = this.Da.ExecuteQuery(sql);

                if (ds.Tables[0].Rows.Count == 1)
                {

                    string query = "update Book_Records set BookName = '" + this.txtBookName.Text + "', BookPathersName = '" +
                                  this.txtBookPName.Text + "', DateOfBirth = '" + this.dtpDOB.Text + "', BookPageN = '" + this.rtxtBookPageN.Text + "',PublishDate = '" + this.dtpPublishDate.Text + "'," +
                                   " BookType = '" + this.txtBookType.Text + "' where BookName = '" +
                                   this.txtBookName.Text + "';";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Data Updated Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Data Upgradation Failed.");
                    }
                }

                else
                {
                    string query = "insert into Book_Records values ('" + this.txtBookName.Text + "','" + this.txtBookName.Text + "','" +
                             this.txtBookPName.Text + "','" + this.dtpDOB.Text + "','" +
                              this.rtxtBookPageN.Text + "' ,'" + this.dtpPublishDate.Text + "', '" + this.txtBookType.Text + "');";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Data Inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Data Insertion Failed.");
                    }


                }
                this.PopulateGridView();

            }


            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnReportRecords_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
