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
    public partial class FormRecords : Form
    {
        private DataAccess Da { get; set; }
        public FormRecords()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void PopulateGridView(string sql = " select * from Book_Records;")
        {
            try
            {
                DataSet ds = this.Da.ExecuteQuery(sql);
                this.dgvRecords.AutoGenerateColumns = false;
                this.dgvRecords.DataSource = ds.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error:" + exc.Message);
            }

        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from Book_Records where BookId = '" + this.txtSearch.Text + "'; ";
            this.PopulateGridView(sql);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtBookId.Text) || String.IsNullOrEmpty(this.txtBookName.Text) ||
                String.IsNullOrEmpty(this.txtBookPName.Text) || String.IsNullOrEmpty(this.dtpDOB.Text) ||
                String.IsNullOrEmpty(this.cbBookType.Text) || String.IsNullOrEmpty(this.rtxtBookPageN.Text) ||
                String.IsNullOrEmpty(this.dtpEntranceDate.Text) || String.IsNullOrEmpty(this.dtpReleaseDate.Text))
                {
                    MessageBox.Show("To add Book Records please fill all the information.");
                    return;
                }



                string query = "insert into Book_Records values ('" + this.txtBookId.Text + "','" + this.txtBookName.Text + "','" +
                             this.txtBookPName.Text + "','" + this.dtpDOB.Text + "','" + this.cbBookType.Text + "','" +
                              this.rtxtBookPageN.Text + "' ,'" + this.dtpEntranceDate.Text + "', '" + this.dtpReleaseDate.Text + "');";

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


            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.dgvRecords.CurrentRow.Cells["BookId"].Value.ToString();
                var name = this.dgvRecords.CurrentRow.Cells["BookName"].Value.ToString();

                string sql = "delete from Book_Records where BookId = '" + id + "';";
                int count = this.Da.ExecuteDML(sql);

                if (count == 1)
                {
                    MessageBox.Show("Book Records " + name + " has been deleted.");
                }
                else
                {
                    MessageBox.Show("Data Deletion Failed.");
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void ClearContent()
        {
            this.txtBookId.Text = "";
            this.txtBookName.Text = "";
            this.txtBookPName.Text = "";
            this.dtpDOB.Text = "";
            this.cbBookType.SelectedIndex = -1;
            this.rtxtBookPageN.Text = "";
            this.dtpEntranceDate.Text = "";
            this.dtpReleaseDate.Text = "";
            this.txtBookId.ReadOnly = true;


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }
    }
}
