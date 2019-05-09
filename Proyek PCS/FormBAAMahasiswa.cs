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
    public partial class FormBAAMahasiswa : Form
    {
        public static OracleConnection conn;
        public FormBAAMahasiswa()
        {
            InitializeComponent();
            conn = new OracleConnection();
        }

        private void FormBAAMahasiswa_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = "Data Source=orcl;User ID=BAA;password=BAA";
            try
            {
                conn.Open();
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void refresh()
        {
            OracleDataAdapter da = new OracleDataAdapter("SELECT*FROM MAHASISWA", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnBackhome_Click(object sender, EventArgs e)
        {
            try
            {
                //conn.Open();
                this.Hide(); new FormBAAHome().ShowDialog();
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                //conn.Open();
                this.Hide(); new FormLogin().ShowDialog();
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
