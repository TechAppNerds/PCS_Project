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
    public partial class FormLogin : Form
    {
        public static OracleConnection conn;
        public FormLogin()
        {
            InitializeComponent(); conn = new OracleConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnectionStringBuilder sb = new OracleConnectionStringBuilder();
            sb.DataSource = textBox1.Text;
            sb.UserID = textBox2.Text;
            sb.Password = textBox3.Text;
            conn = new OracleConnection(sb.ToString());
            try
            {
                if (conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open(); FormLoginUserSQL.dts = textBox1.Text; FormLoginUserSQL.userid = textBox2.Text;
                FormLoginUserSQL.pass = textBox3.Text; this.Hide(); new FormLoginUserSQL().ShowDialog();
                conn.Close(); this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
