using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Proyek_PCS
{
    public partial class ConfirmDelete : Form
    {
        public static OracleConnection conn;
        public static string dts, userid, pass;
        public ConfirmDelete()
        {
            InitializeComponent(); conn = new OracleConnection();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '*';
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=" + dts + ";User ID=" + userid + ";password=" + pass + "";
            try
            {
                if (String.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("Field Username Wajib Diisi");
                }
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Field Password Wajib Diisi");
                }
                else if (!String.IsNullOrEmpty(txtUsername.Text)&&!String.IsNullOrEmpty(txtPassword.Text))
                {
                    if (!txtUsername.Text.Equals(userid))
                    {
                        MessageBox.Show("Field Username Salah"); FormBAAJadwalMatakuliah.cekdelete = false; this.Hide(); this.Close();
                    }
                    if (!txtPassword.Text.Equals(pass))
                    {
                        MessageBox.Show("Field Password Salah"); FormBAAJadwalMatakuliah.cekdelete = false; this.Hide(); this.Close();
                    }
                    if (txtUsername.Text.Equals(userid) && txtPassword.Text.Equals(pass))
                    {
                        FormBAAJadwalMatakuliah.cekdelete = true; this.Hide(); this.Close();
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
