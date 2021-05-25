using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using GTLCore;
using Services;

namespace GTLGeorgiaTechLibrary
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        EntityState objState = EntityState.Unchanged;
        public Form1()
        {
            InitializeComponent();
        }
        void ClearInput()
        {
            txtName.Text = null;
            txtMiddleName.Text = null;
            txtLastName.Text = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                personBindingSource.DataSource = PersonService.GetAll();
                memberBindingSource.DataSource = MemberService.GetAll();
                materialBindingSource.DataSource = MaterialService.GetAll();
                pContainer.Enabled = false;
                memberPContainer.Enabled = false;
                materialPConatiner.Enabled = false;
                bindingSourceMaterial.AutoGenerateColumns = false;

                
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            pContainer.Enabled = true;
            personBindingSource.Add(new Person());
            personBindingSource.MoveLast();
            txtName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pContainer.Enabled = false;
            personBindingSource.ResetBindings(false);
            //ClearInput();
            this.Form1_Load(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            objState = EntityState.Changed;
            pContainer.Enabled = true;
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objState = EntityState.Deleted;
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Person obj = personBindingSource.Current as Person;
                    if (obj != null)
                    {

                        bool result = PersonService.Delete(obj.id);
                        if (result)
                        {
                            personBindingSource.RemoveCurrent();
                            pContainer.Enabled = false;
                            objState = EntityState.Unchanged;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                personBindingSource.EndEdit();
                Person obj = personBindingSource.Current as Person;
                if (obj != null)
                {
                    obj = PersonService.Save(obj, objState);
                    metroGrid.Refresh();
                    pContainer.Enabled = false;
                    objState = EntityState.Unchanged;

                }
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMember_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            memberPContainer.Enabled = true;
            memberBindingSource.Add(new Member());
            memberBindingSource.MoveLast();
            txtSsn.Focus();
        }
        private void addToLoanList_Click(object sender, EventArgs e)
        {
            bindingSourceMaterial.Rows.Add(txtLoanmaterialId.Text, txtLoanSsn.Text);
        }
        private void Removebook_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.bindingSourceMaterial.SelectedRows)
            {
                bindingSourceMaterial.Rows.RemoveAt(item.Index);
            }
        }
        private void SaveLoans_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure these details are correct?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string mainconn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(mainconn);

                    foreach (DataGridViewRow item in bindingSourceMaterial.Rows)
                    {
                        string sqlquery = "INSERT INTO loan VALUES(@start_date, @return_date, @m_ssn, @member_loan_no)";
                        SqlCommand sql = new SqlCommand(sqlquery, sqlConnection);
                        if (item.IsNewRow) continue;
                        {
                            sql.Parameters.AddWithValue("@start_date", DateTime.Now);
                            sql.Parameters.AddWithValue("@return_date", SqlDateTime.Null);
                            sql.Parameters.AddWithValue("@m_ssn", item.Cells["m_ssn"].Value ?? DBNull.Value);
                            sql.Parameters.AddWithValue("@member_loan_no", item.Cells["member_loan_no"].Value ?? DBNull.Value);
                        }
                        sqlConnection.Open();
                        sql.ExecuteNonQuery();
                        sqlConnection.Close();
                        MessageBox.Show("Loan is submitted.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    bindingSourceMaterial.Rows.Clear();
                }
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void metroCheckBoxIsProfessor_CheckStateChanged(object sender, EventArgs e)
        {
            if (metroCheckBoxIsProfessor.CheckState == CheckState.Checked)
                metroCheckBoxIsProfessor.Text = "is professor";
            else if (metroCheckBoxIsProfessor.CheckState == CheckState.Unchecked)
                metroCheckBoxIsProfessor.Text = "Is not professor";
            else metroCheckBoxIsProfessor.Text = "?";
        }

        private void metroButton_Click(object sender, EventArgs e)
        {

        }

        private void editMember_Click(object sender, EventArgs e)
        {
            objState = EntityState.Changed;
            memberPContainer.Enabled = true;
            txtSsn.Focus();
        }

        private void deleteMember_Click(object sender, EventArgs e)
        {
            objState = EntityState.Deleted;
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Member obj = memberBindingSource.Current as Member;
                    if (obj != null)
                    {

                        bool result = MemberService.Delete(obj.ssn);
                        if (result)
                        {
                            memberBindingSource.RemoveCurrent();
                            memberPContainer.Enabled = false;
                            objState = EntityState.Unchanged;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelMember_Click(object sender, EventArgs e)
        {
            memberPContainer.Enabled = false;
            memberBindingSource.ResetBindings(false);
            //ClearInput();
            this.Form1_Load(sender, e);
        }

        private void saveMember_Click(object sender, EventArgs e)
        {
            try
            {
                memberBindingSource.EndEdit();
                Member obj = memberBindingSource.Current as Member;
                if (obj != null)
                {
                    obj = MemberService.Save(obj, objState);
                    metroGridMember.Refresh();
                    memberPContainer.Enabled = false;
                    objState = EntityState.Unchanged;

                }
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listOfLoans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addMaterial_Click(object sender, EventArgs e)
        {
            objState = EntityState.Added;
            materialPConatiner.Enabled = true;
            materialBindingSource.Add(new Material());
            materialBindingSource.MoveLast();
            txtIsbn.Focus();
        }

        private void editMaterial_Click(object sender, EventArgs e)
        {
            objState = EntityState.Changed;
            materialPConatiner.Enabled = true;
            txtIsbn.Focus();
        }

        private void cancelMaterial_Click(object sender, EventArgs e)
        {
            materialPConatiner.Enabled = false;
            materialBindingSource.ResetBindings(false);
            //ClearInput();
            this.Form1_Load(sender, e);
        }

        private void deleteMaterial_Click(object sender, EventArgs e)
        {
            objState = EntityState.Deleted;
            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Material obj = materialBindingSource.Current as Material;
                    if (obj != null)
                    {

                        bool result = MaterialService.Delete(obj.id);
                        if (result)
                        {
                            materialBindingSource.RemoveCurrent();
                            materialPConatiner.Enabled = false;
                            objState = EntityState.Unchanged;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                materialBindingSource.EndEdit();
                Material obj = materialBindingSource.Current as Material;
                if (obj != null)
                {
                    obj = MaterialService.Save(obj, objState);
                    metroGrid.Refresh();
                    materialPConatiner.Enabled = false;
                    objState = EntityState.Unchanged;

                }
            }
            catch (Exception ex)
            {

                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLoanmaterialId.Text = null;
            txtLoanSsn.Text = null;
        }
    }
}
